@echo off
cls

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%~1")

".paket\paket.exe" "restore"
"packages\build\FAKE\tools\FAKE.exe" "build.fsx" "target=%TARGET%"