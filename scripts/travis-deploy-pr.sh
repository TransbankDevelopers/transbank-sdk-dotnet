#!/bin/sh

cd Transbank
dotnet pack Transbank.csproj -c release --version-suffix ci-`$TRAVIS_PULL_REQUEST` --output nupkgs -v d
curl -F package=@nupkgs/`ls nupkgs/ | grep nupkg` https://`$GEMFURY_TOKEN`@push.fury.io/h_app104067847/
