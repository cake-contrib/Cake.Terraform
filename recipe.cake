#load nuget:?package=Cake.Recipe&version=3.1.1

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Terraform",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Terraform",
                            webHost: "cake-contrib.github.io",
                            webLinkRoot: "Cake.Terraform",
                            webBaseEditUrl: "https://github.com/cake-contrib/Cake.Terraform/tree/develop/docs/input",
                            shouldRunDotNetCorePack: true
                            //preferredBuildProviderType: BuildProviderType.GitHubActions,
                            //preferredBuildAgentOperatingSystem: PlatformFamily.Linux
                            );

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();

