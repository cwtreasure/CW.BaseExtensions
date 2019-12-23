BASE_PATH=$(cd `dirname $0`;pwd)

dotnet pack -c Release $BASE_PATH/src/CW.BaseExtensions/CW.BaseExtensions.csproj
