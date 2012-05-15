#I @"Source\packages\Fake.1.64.6\tools"
#r "FakeLib.dll"

open Fake
open Fake.Git
open System.Linq
open System.Text.RegularExpressions
open System.IO

(* properties *)
let authors = ["Max Malook, Marco Rasp, Stefan Senff"]
let projectName = "FeatureSwitcher"

TraceEnvironmentVariables()

let version =
    if hasBuildParam "version" then getBuildParam "version" else
    if isLocalBuild then getLastTag() else
    // version is set to the last tag retrieved from GitHub Rest API
    let url = sprintf "http://github.com/api/v2/json/repos/show/mexx/%s/tags" projectName
    tracefn "Downloading tags from %s" url
    let tagsFile = REST.ExecuteGetCommand null null url
    let r = new Regex("[,{][\"]([^\"]*)[\"]")
    [for m in r.Matches tagsFile -> m.Groups.[1]]
        |> List.map (fun m -> m.Value)
        |> List.filter ((<>) "tags")
        |> List.max

let NugetKey = getBuildParamOrDefault "nugetkey" ""

(* Directories *)
let targetPlatformDir = getTargetPlatformDir "v4.0.30319"
let sourceDir = @".\Source\"
let packagesDir = sourceDir + @"packages\"

let buildDir = @".\Build\"
let testDir = buildDir
let testOutputDir = buildDir + @"Specs\"
let nugetDir = buildDir + @"NuGet\"
let deployDir = @".\Release\"

(* files *)
let slnReferences = !! (sourceDir + @"*.sln")
let nugetPath = sourceDir + @".nuget\NuGet.exe"

(* tests *)
let MSpecVersion = lazy ( GetPackageVersion packagesDir "Machine.Specifications" )
let mspecTool = lazy( sprintf @"%s\Machine.Specifications.%s\tools\mspec-clr4.exe" packagesDir (MSpecVersion.Force()) )

(* Targets *)
Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; testOutputDir; nugetDir; deployDir]
)

Target "SetAssemblyInfo" (fun _ ->
    let replaceAssemblyInfoVersions project =
        ReplaceAssemblyInfoVersions
            (fun p ->
            {p with
                AssemblyVersion = version;
                AssemblyFileVersion = version;
                AssemblyInformationalVersion = version;
                OutputFileName = sprintf @".\Source\%s\Properties\AssemblyInfo.cs" project})

    ["FeatureSwitcher"; "FeatureSwitcher.Configuration"]
        |> Seq.iter replaceAssemblyInfoVersions
)

Target "BuildApp" (fun _ ->
    MSBuildRelease buildDir "Build" slnReferences
        |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    ActivateFinalTarget "DeployTestResults"
    !+ (testDir + "/*.Specs.dll")
      ++ (testDir + "/*.Examples.dll")
        |> Scan
        |> MSpec (fun p ->
                    {p with
                        ToolPath = mspecTool.Force()
                        HtmlOutputDir = testOutputDir})
)

FinalTarget "DeployTestResults" (fun () ->
    !+ (testOutputDir + "\**\*.*")
      |> Scan
      |> Zip testOutputDir (sprintf "%sMSpecResults.zip" deployDir)
)

Target "BuildZip" (fun _ ->
    !+ (buildDir + "/**/*.*")
      -- "*.zip"
      -- "**/*.Specs.dll"
      -- "**/*.Specs.pdb"
        |> Scan
        |> Zip buildDir (deployDir @@ sprintf "%s-%s.zip" projectName version)
)

Target "BuildNuGet" (fun _ ->
    let nugetLibDir = nugetDir @@ "lib" @@ "4.0"

    let buildPackage contents project description dependencies = 
        CleanDirs [nugetLibDir]

        contents
            |> CopyTo nugetLibDir

        NuGet (fun p ->
            {p with
                ToolPath = nugetPath
                Authors = authors
                Project = project
                Description = description
                Version = version
                Dependencies = dependencies
                OutputPath = nugetDir
                AccessKey = NugetKey
                Publish = NugetKey <> "" })
            (sprintf @".\Source\%s\Package.nuspec" project)

        !! (nugetDir + "FeatureSwitcher.*.nupkg")
          |> CopyTo deployDir

    buildPackage [buildDir @@ "FeatureSwitcher.dll"] "FeatureSwitcher" "" []
    buildPackage [buildDir @@ "FeatureSwitcher.Configuration.dll"] "FeatureSwitcher.Configuration" "Configuration package." [projectName, RequireExactly (NormalizeVersion version)]
)

Target "Default" DoNothing
Target "Deploy" DoNothing

// Build order
"Clean"
  ==> "SetAssemblyInfo"
  ==> "BuildApp"
  ==> "Test"
  ==> "BuildZip"
  ==> "BuildNuGet"
  ==> "Deploy"
  ==> "Default"

// start build
RunParameterTargetOrDefault  "target" "Default"