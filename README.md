**Analysis BEGIN, dotnet build, dotnet test, npm test and END commands**

```
dotnet sonarscanner begin /d:sonar.exclusions="**/node_modules/**/*" /k:multi-language-analysis-dotnet /d:sonar.host.url=http://localhost:9000 /d:sonar.token="<token>" /d:sonar.verbose=true  /d:sonar.javascript.lcov.reportPaths="**/lcov.info" /d:sonar.cs.dotcover.reportsPaths="dotCover.Output.html" /d:sonar.cs.xunit.reportsPaths="**/xunit_test_result.xml"  > sonar-analysis.log && \
dotnet build ".../multi-language-analysis-dotnet/unit-testing-using-dotnet-test/unit-testing-using-dotnet-test.sln" --no-incremental >> sonar-analysis.log && \
dotnet dotcover test ".../multi-language-analysis-dotnet/unit-testing-using-dotnet-test/unit-testing-using-dotnet-test.sln" --dcReportType=HTML --logger "xunit;LogFileName=xunit_test_result.xml" >> sonar-analysis.log && \
npm test >> sonar-analysis.log && \
dotnet sonarscanner end /d:sonar.token="<token>" >> sonar-analysis.log
```