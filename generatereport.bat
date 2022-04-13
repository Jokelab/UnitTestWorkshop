call rmdir %CD%\coveragereport /S /Q
call rmdir %CD%\FormulaOne.Tests\TestResults /S /Q
call dotnet test --collect:"XPlat Code Coverage"
call dotnet tool install -g dotnet-reportgenerator-globaltool
call reportgenerator -reports:"*\TestResults\*\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html