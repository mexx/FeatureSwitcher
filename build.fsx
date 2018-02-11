#I @"Source/packages/FAKE/tools"
#r "FakeLib.dll"

open System
open Fake
open Fake.DotNetCli
open Fake.DotNet.NuGet.NuGet

(* properties *)
let projectName = "FeatureSwitcher"

let ReleaseCandidate = getBuildParamOrDefault "releaseCandidate" (System.DateTime.Now.ToString("yyyyMMddHHmmss"))
let NugetKey = getBuildParamOrDefault "nuget.key" ""

(* Directories *)
let sourceDir = "Source"

let buildDir = "Build"
let testDir = buildDir
let nugetDir = buildDir @@ "NuGet/"
let deployDir = "./Release/"

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
Target "Clean" <| fun _ ->
    CleanDirs [buildDir; testDir; nugetDir; deployDir]

Target "BuildApp" <| fun _ ->
     DotNetCli.Restore (fun p ->
        { p with WorkingDir = sourceDir } )
     DotNetCli.Build (fun p ->
        { p with
            WorkingDir = sourceDir
            Configuration = "Release"
            Output = "../../" ^ buildDir } )

Target "Test" <| fun _ ->
    !! "Source/**/*.Specs.csproj"
    |> Seq.iter (fun proj ->
        DotNetCli.Test <| fun p ->
            { p with
                Configuration = "Release"
                Project = proj } )

Target "BuildNuGet" <| fun _ ->
    DotNetCli.Pack
      (fun p ->
         { p with
            Configuration = "Release"
            OutputPath = "../../" ^ nugetDir
            WorkingDir = sourceDir
            AdditionalArgs=[String.Format("/p:PackageVersion={0}", packageVersion())] } )

    !! (nugetDir @@ (sprintf "%s.*.nupkg" projectName))
        |> CopyTo deployDir

    if NugetKey <> ""
    then
        NuGetPublish (fun p ->
            { p with
                Project = projectName
                Version = packageVersion()
                OutputPath = nugetDir
                WorkingDir = nugetDir
                AccessKey = NugetKey } )

Target "Default" DoNothing

// Build order
"Clean"
  ==> "BuildApp"
  ==> "Test"
  ==> "BuildNuGet"
  ==> "Default"

// start build
RunTargetOrDefault "Default"