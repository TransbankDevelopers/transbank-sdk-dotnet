#!/bin/sh

#Deploy New Tags to Nuget
if [ ! -z "$TRAVIS_TAG" ]
then 
    echo "Tag found"
    cd Transbank
    if ( echo $TRAVIS_TAG | egrep -i '^v[0-9]+\.[0-9]+\.[0-9]+')
    then
            VERSION_NUMBER=${TRAVIS_TAG:1}
            dotnet pack Transbank.csproj -c release  -p:Version=$VERSION_NUMBER --output nupkgs -v d
    else
            dotnet pack Transbank.csproj -c release --version-suffix ci-$TRAVIS_BUILD_ID
    fi
    dotnet nuget push nupkgs/`ls nupkgs/ | grep nupkg` -k $NUGET_DEPLOY_KEY -s https://api.nuget.org/v3/index.json
else
    echo "not on a tag no deploy trigered"
fi
