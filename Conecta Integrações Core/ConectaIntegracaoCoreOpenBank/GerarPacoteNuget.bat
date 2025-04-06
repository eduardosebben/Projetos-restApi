echo off
"nuget.exe" pack -Build -OutputDirectory "J:\desenv\nugetPrivateServer_TempPKGs" -Properties Configuration=Release
"nuget.exe" init "J:\desenv\nugetPrivateServer_TempPKGs" "J:\desenv\nugetPrivateServer"
pause