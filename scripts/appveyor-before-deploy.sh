#!/bin/sh
cd Transbank
if ($APPVEYOR_REPO_TAG && (echo $APPVEYOR_REPO_TAG_NAME | egrep -i '^v[0-9]+\.[0-9]+\.[0-9]+'))
then
    VERSION_NUMBER=${APPVEYOR_REPO_TAG_NAME:1}
    dotnet pack Transbank.csproj -c release  -p:Version=$VERSION_NUMBER --output nupkgs -v d
else
    dotnet pack Transbank.csproj -c release --version-suffix ci-$APPVEYOR_BUILD_ID
fi
