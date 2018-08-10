#!/bin/sh

dotnet restore
mono tools/sonar/SonarQube.Scanner.MSBuild.exe begin /k:dotnetsdk  /d:sonar.organization=transbankdevelopers /d:sonar.login=${SONAR_TOKEN} /d:sonar.host.url=https://sonarcloud.io /d:sonar.cs.vstest.reportsPaths="./TransbankTest/TestResults/*.trx"
dotnet build
cd TransbankTest
dotnet test --logger:trx
cd ..
mono tools/sonar/SonarQube.Scanner.MSBuild.exe end /d:sonar.login=${SONAR_TOKEN}