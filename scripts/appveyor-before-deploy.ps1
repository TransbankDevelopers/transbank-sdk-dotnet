Write-Host "Before Deploy Script"
Set-Location Transbank
if ($env:APPVEYOR_REPO_TAG_NAME -Match "^v[0-9]+\.[0-9]+\.[0-9]+" ){
    Write-Host "Version Tag Found Deploy new Nuget Release"
    $VERSION_NUMBER=$env:APPVEYOR_REPO_TAG_NAME.substring(1)
    dotnet.exe pack Transbank.csproj -c release  -p:Version=$VERSION_NUMBER --output nupkgs
    Write-Host "Done"
}
else{
    Write-Host "No Version Tag Found deploy prerelease to Nuget"
    dotnet.exe pack Transbank.csproj -c release --version-suffix ci-$env:APPVEYOR_BUILD_ID --output nupkgs
    Write-Host "Done"
}
Set-Location ..