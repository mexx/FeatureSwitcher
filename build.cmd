@echo off

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%~1")

SET FAKE_VERSION=5.0.0-beta010

:Build
cls

echo Installing FAKE %FAKE_VERSION%
"Source\.nuget\NuGet.exe" "install" "FAKE" "-OutputDirectory" "Source\packages" "-ExcludeVersion" "-Version" "%FAKE_VERSION%"

"Source\packages\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%"

rem Bail if we're running a TeamCity build.
if defined TEAMCITY_PROJECT_NAME goto Quit

rem Loop the build script.
set CHOICE=nothing
echo (Q)uit, (Enter) runs the build again
set /P CHOICE=
if /i "%CHOICE%"=="Q" goto :Quit

GOTO Build

:Quit
exit /b %errorlevel%