#I @"Source/packages/FAKE/tools"
#r "FakeLib.dll"

open Fake

(* properties *)
let authors = ["Max Malook, Marco Rasp, Stefan Senff"]
let projectName = "FeatureSwitcher"

TraceEnvironmentVariables()

let ReleaseCandidate = getBuildParamOrDefault "releaseCandidate" (System.DateTime.Now.ToString("yyyyMMddHHmmss"))
let NugetKey = getBuildParamOrDefault "nuget.key" ""

(* Directories *)
let sourceDir = "./Source/"

let buildDir = "./Build/"
let testDir = buildDir
let testOutputDir = buildDir @@ "Specs/"
let nugetDir = buildDir @@ "NuGet/"
let deployDir = "./Release/"

(* files *)
let slnReferences = !! (sourceDir @@ "*.sln")

(* helper functions *)
let packageVersion() =
    let projectAssembly = buildDir @@ (sprintf "%s.dll" projectName)

    let assemblyName = System.Reflection.AssemblyName.GetAssemblyName(projectAssembly)

    let version = assemblyName.Version.ToString(3)

    if ReleaseCandidate = "false" then
        version
    else
        sprintf "%s-rc%s" version ReleaseCandidate

(* Targets *)
Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; testOutputDir; nugetDir; deployDir]
)

Target "BuildApp" (fun _ ->
    MSBuildRelease buildDir "Build" slnReferences
        |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    ActivateFinalTarget "DeployTestResults"
    !! (testDir @@ "/*.Specs.dll")
        |> MSpec (fun p ->
            {p with
                HtmlOutputDir = testOutputDir})
)

FinalTarget "DeployTestResults" (fun () ->
    !! (testOutputDir @@ "/**/*.*")
        |> Zip testOutputDir (deployDir @@ "MSpecResults.zip")
)

Target "BuildZip" (fun _ ->
    !! (buildDir @@ sprintf "/%s.*" projectName)
      -- "**/*Specs*"
        |> Zip buildDir (deployDir @@ sprintf "%s-%s.zip" projectName (packageVersion()))
)

Target "BuildNuGet" (fun _ ->
    let nugetLibDir = nugetDir @@ "lib" @@ "4.0"

    CleanDirs [nugetLibDir]

    !! (buildDir @@ (sprintf "%s.dll" projectName))
      ++ (buildDir @@ (sprintf "%s.xml" projectName))
        |> CopyTo nugetLibDir

    NuGet (fun p ->
        {p with
            Authors = authors
            Project = projectName
            Description = ""
            Version = packageVersion()
            Dependencies = []
            ToolPath = sourceDir @@ ".nuget" @@ "NuGet.exe" |> FullName
            OutputPath = nugetDir |> FullName
            WorkingDir = nugetDir |> FullName
            AccessKey = NugetKey
            Publish = NugetKey <> "" })
        (sourceDir @@ projectName @@ "Package.nuspec")

    !! (nugetDir @@ (sprintf "%s.*.nupkg" projectName))
        |> CopyTo deployDir
)

Target "NotifyTeamCity" (fun _ ->
    let setParameter name value =
        sprintf "##teamcity[setParameter name='%s' value='%s']"
            (EncapsulateSpecialChars name)
            (EncapsulateSpecialChars value)
        |> sendStrToTeamCity

    setParameter "env.packageVersion" (packageVersion())
)

Target "Default" DoNothing

// Build order
"Clean"
  ==> "BuildApp"
  ==> "Test"
  ==> "BuildZip"
  ==> "BuildNuGet"
  =?> ("NotifyTeamCity", TeamCity = buildServer)
  ==> "Default"

// start build
RunParameterTargetOrDefault  "target" "Default"