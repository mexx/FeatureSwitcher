@echo off

:Build
cls

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%~1")

SET VERSION=

IF NOT [%2]==[] (set VERSION="%~2")

echo Installing FAKE
"Source\.nuget\NuGet.exe" "install" "FAKE" "-OutputDirectory" "Source\packages" "-Version" "1.64.5"

"Source\packages\FAKE.1.64.5\tools\Fake.exe" "build.fsx" "target=%TARGET%" %VERSION%

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