#I @"Source\packages\Fake\tools"
#r "FakeLib.dll"

open Fake

(* properties *)
let authors = ["Max Malook, Marco Rasp, Stefan Senff"]
let projectName = "FeatureSwitcher"

TraceEnvironmentVariables()

let version = if isLocalBuild then getBuildParamOrDefault "version" "0.0.0.1" else buildVersion
let packageVersion = getBuildParamOrDefault "packageVersion" version

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

(* Targets *)
Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; testOutputDir; nugetDir; deployDir]
)

Target "SetAssemblyInfo" (fun _ ->
    ReplaceAssemblyInfoVersions
        (fun p ->
        {p with
            AssemblyVersion = version;
            AssemblyFileVersion = version;
            AssemblyInformationalVersion = version;
            OutputFileName = sourceDir @@ projectName @@ "/Properties/AssemblyInfo.cs"})
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
        |> Zip buildDir (deployDir @@ sprintf "%s-%s.zip" projectName version)
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
            Version = packageVersion
            Dependencies = []
            OutputPath = nugetDir
            WorkingDir = nugetDir
            AccessKey = NugetKey
            Publish = NugetKey <> "" })
        (sourceDir @@ projectName @@ "Package.nuspec")

    !! (nugetDir @@ (sprintf "%s.*.nupkg" projectName))
        |> CopyTo deployDir
)

Target "Default" DoNothing

// Build order
"Clean"
  ==> "SetAssemblyInfo"
  ==> "BuildApp"
  ==> "Test"
  ==> "BuildZip"
  ==> "BuildNuGet"
  ==> "Default"

// start build
RunParameterTargetOrDefault  "target" "Default"