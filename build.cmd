@echo off
cls

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%~1")

SET FAKE_VERSION=2.2.0

echo Installing FAKE %FAKE_VERSION%
"Source\.nuget\NuGet.exe" "install" "FAKE" "-OutputDirectory" "Source\packages" "-ExcludeVersion" "-Version" "%FAKE_VERSION%"

"Source\packages\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%"
