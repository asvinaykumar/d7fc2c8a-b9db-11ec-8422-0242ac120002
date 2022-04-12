#!/bin/bash
set -eu -o pipefail

dotnet restore /NUnitTest/NUnitTest.csproj
dotnet test /NUnitTest/NUnitTest.csproj