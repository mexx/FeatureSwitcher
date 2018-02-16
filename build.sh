#!/usr/bin/env bash

set -eu

cd "$(dirname "$0")"

TARGET="Default"
if [ "$1" != "" ]
then
  TARGET="$1"
fi

PAKET_EXE=.paket/paket.exe
FAKE_EXE=packages/build/FAKE/tools/FAKE.exe

FSIARGS=""
FSIARGS2=""
OS=${OS:-"unknown"}
if [ "$OS" != "Windows_NT" ]
then
  # Can't use FSIARGS="--fsiargs -d:MONO" in zsh, so split it up
  # (Can't use arrays since dash can't handle them)
  FSIARGS="--fsiargs"
  FSIARGS2="-d:MONO"
fi

run() {
  echo $@
  if [ "$OS" != "Windows_NT" ]
  then
    mono "$@"
  else
    "$@"
  fi
}

run $PAKET_EXE restore
run $FAKE_EXE "target=$TARGET" $FSIARGS $FSIARGS2 build.fsx