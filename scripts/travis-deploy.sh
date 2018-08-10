#!/bin/sh

#Deploy New Tags to Nuget
if [ "$TRAVIS_PULL_REQUEST" = "false" ]; then
    cd Transbank
    dotnet pack Transbank.csproj -c release --output nupkgs -v d
    dotnet nuget push nupkgs/`ls nupkgs/ | grep nupkg` -k $NUGET_DEPLOY_KEY -s https://api.nuget.org/v3/index.json
fi
