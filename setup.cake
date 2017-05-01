#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Terraform",
                            repositoryOwner: "erikvanbrakel",
                            repositoryName: "Cake.Terraform",
                            appVeyorAccountName: "erikvanbrakel",
                            webHost: "erikvanbrakel.github.io",
                            webLinkRoot: "Cake.Terraform",
                            webBaseEditUrl: "https://github.com/erikvanbrakel/Cake.Terraform/tree/develop/docs/input"
                            );

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                                BuildParameters.RootDirectoryPath + "/src/Cake.Terraform.Tests/**/*.cs"
                            },
                            dupFinderThrowExceptionOnFindingDuplicates: false,
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* ",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.Run();
