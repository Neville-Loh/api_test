# API Testing Using SpecFlow

This is a .NET Unit Test application which uses nUnit and SpecFlow for API-testing.
SpecFlow is a BDD test framework  

BDD aims to create a shared understanding of how an application should behave by discovering new features based on concrete examples. Key examples are then formalized with natural language following a Given/When/Then structure.

Syntax such as Automated Gherkin scenarios are used in the projects.


The API that is tested is retrieved from https://jsonplaceholder.typicode.com/


## Scalability
SpecFlow allow user to build multiple examples test case for one scenarios.

Example:
![](/img/test.png)


## Devops pipeline
Test pipleline is not used in the projects since the api is external. If user
were to implement such a system, one of way to implement it is a build/test pipeline.

This is one of the sample using AWS CodeBuild Service.
```yaml
version: 0.2

phases:
    install:
        runtime-versions:
            dotnet: 3.1
    build:
        commands:
            - dotnet build -c Release ./CodeBuildDotnetTestReportExample/CodeBuildDotnetTestReportExample.csproj
            - dotnet test -c Release ./CodeBuildDotnetTestReportExample.Tests/CodeBuildDotnetTestReportExample.Tests.csproj

```

Where test will be trigger whenever a new artifact is built.
