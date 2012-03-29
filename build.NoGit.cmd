@echo off

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%~1")

build.cmd %TARGET% "version=0.0.0.1"
