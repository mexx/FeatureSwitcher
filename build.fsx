#I @"Source\packages\Fake.1.64.5\tools"
#r "FakeLib.dll"

open Fake
open Fake.Git
open System.Linq
open System.Text.RegularExpressions
open System.IO

(* properties *)
let authors = ["Max Malook, Marco Rasp, Stefan Senff"]
let projectName = "FeatureSwitcher"
let copyright = "Copyright - FeatureSwitcher 2012"
let NugetKey = if System.IO.File.Exists @".\key.txt" then ReadFileAsString @".\key.txt" else ""

let version =
    if hasBuildParam "version" then getBuildParam "version" else
    if isLocalBuild then getLastTag() else
    // version is set to the last tag retrieved from GitHub Rest API
    let url = "http://github.com/api/v2/json/repos/show/mexx/FeatureSwitcher/tags"
    tracefn "Downloading tags from %s" url
    let tagsFile = REST.ExecuteGetCommand null null url
    let r = new Regex("[,{][\"]([^\"]*)[\"]")
    [for m in r.Matches tagsFile -> m.Groups.[1]]
        |> List.map (fun m -> m.Value)
        |> List.filter ((<>) "tags")
        |> List.max

let title = if isLocalBuild then sprintf "%s (%s)" projectName <| getCurrentHash() else projectName


(* Directories *)
let buildDir = @".\Build\"
let packagesDir = @".\Source\packages\"
let docsDir = buildDir + @"Documentation\"
let testOutputDir = buildDir + @"Specs\"
let nugetDir = buildDir + @"NuGet\"
let testDir = buildDir
let deployDir = @".\Release\"
let targetPlatformDir = getTargetPlatformDir "v4.0.30319"
let nugetLibDir = nugetDir + @"lib\"

(* files *)
let slnReferences = !! @".\Source\*.sln"
let nugetPath = @".\Source\.nuget\NuGet.exe"

(* tests *)
let MSpecVersion = lazy ( GetPackageVersion packagesDir "Machine.Specifications" )
let mspecTool = lazy( sprintf @".\Source\packages\Machine.Specifications.%s\tools\mspec-clr4.exe" (MSpecVersion.Force()) )

(* flavours *)
//let FeatureSwitcherVersion = GetPackageVersion packagesDir "FeatureSwitcher"

(* Targets *)
Target "Clean" (fun _ -> CleanDirs [buildDir; testDir; deployDir; docsDir; testOutputDir] )


Target "BuildApp" (fun _ ->
    AssemblyInfo
      (fun p ->
        {p with
            CodeLanguage = CSharp;
            AssemblyVersion = version;
            AssemblyTitle = title;
            AssemblyDescription = "A framework for feature toggles/switches";
            AssemblyCompany = projectName;
            AssemblyCopyright = copyright;
            Guid = "5a8365f3-ecf8-4e56-b0ed-612b5fbe7826";
            OutputFileName = @".\Source\GlobalAssemblyInfo.cs"})

    slnReferences
        |> MSBuildRelease buildDir "Build"
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

Target "GenerateDocumentation" (fun _ ->
    !+ (buildDir + "Machine.Fakes.dll")
      |> Scan
      |> Docu (fun p ->
          {p with
              ToolPath = "./tools/docu/docu.exe"
              TemplatesPath = "./tools/docu/templates"
              OutputPath = docsDir })
)

Target "ZipDocumentation" (fun _ ->
    !! (docsDir + "/**/*.*")
      |> Zip docsDir (deployDir + sprintf "Documentation-%s.zip" version)
)

Target "BuildZip" (fun _ ->
    !+ (buildDir + "/**/*.*")
      -- "*.zip"
      -- "**/*.Specs.*"
        |> Scan
        |> Zip buildDir (deployDir + sprintf "%s-%s.zip" projectName version)
)

Target "BuildNuGet" (fun _ ->
    CleanDirs [nugetDir; nugetLibDir]

    [buildDir + "FeatureSwitcher.dll"]
        |> CopyTo nugetLibDir


    NuGet (fun p ->
        {p with
            ToolPath = nugetPath
            Authors = authors
            Project = projectName
            Version = version
            OutputPath = nugetDir
            AccessKey = NugetKey
            Publish = NugetKey <> "" })
        "FeatureSwitcher.nuspec"

    !! (nugetDir + "FeatureSwitcher.*.nupkg")
      |> CopyTo deployDir
)

(*
Target "BuildNuGetFlavours" (fun _ ->
    Flavours
      |> Seq.iter (fun (flavour) ->
            let flavourVersion = GetPackageVersion packagesDir flavour
            CleanDirs [nugetDir; nugetLibDir]

            [buildDir + sprintf "Machine.Fakes.Adapters.%s.dll" flavour]
              |> CopyTo nugetLibDir

            NuGet (fun p ->
                {p with
                    Authors = if flavour = "NSubstitute" then "Steffen Forkmann" :: authors else authors
                    Project = sprintf "%s.%s" projectName flavour
                    Description = sprintf " This is the adapter for %s %s" flavour flavourVersion
                    Version = version
                    OutputPath = nugetDir
                    Dependencies =
                        ["Machine.Fakes",RequireExactly (NormalizeVersion version)
                         flavour,RequireExactly flavourVersion]
                    AccessKey = NugetKey
                    Publish = NugetKey <> "" })
                "machine.fakes.nuspec"

            !! (nugetDir + sprintf "Machine.Fakes.%s.*.nupkg" flavour)
              |> CopyTo deployDir)
)
*)

Target "Default" DoNothing
Target "Deploy" DoNothing

// Build order
"Clean"
  ==> "BuildApp"
  ==> "Test"
  ==> "BuildZip"
//  ==> "GenerateDocumentation"
//  ==> "ZipDocumentation"
  ==> "BuildNuGet"
//  ==> "BuildNuGetFlavours"
  ==> "Deploy"
  ==> "Default"

// start build
RunParameterTargetOrDefault  "target" "Default"