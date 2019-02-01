#!/bin/sh
echo "Before Deploy Script"
cd Transbank
if (echo $APPVEYOR_REPO_TAG_NAME | egrep -i '^v[0-9]+\.[0-9]+\.[0-9]+')
then
    echo "Version Tag Found Deploy new Nuget Release"
    VERSION_NUMBER=${APPVEYOR_REPO_TAG_NAME:1}
    dotnet pack Transbank.csproj -c release  -p:Version=$VERSION_NUMBER --output nupkgs -v d
    echo "Done"
else
    echo "No Version Tag Found deploy prerelease to Nuget"
    dotnet pack Transbank.csproj -c release --version-suffix ci-$APPVEYOR_BUILD_ID
    echo "Done"
fi
