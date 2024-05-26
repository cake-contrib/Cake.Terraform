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
                            shouldRunDotNetCorePack: true,
                            shouldRunCodecov: false
                            //preferredBuildProviderType: BuildProviderType.GitHubActions,
                            //preferredBuildAgentOperatingSystem: PlatformFamily.Linux
                            );

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolPreprocessorDirectives(
  gitReleaseManagerGlobalTool: "#tool dotnet:?package=GitReleaseManager.Tool&version=0.17.0");

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();

