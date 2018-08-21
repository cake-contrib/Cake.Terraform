using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    using System.Collections.Generic;

    public class TerraformRefreshTests
    {
        public class TheExecutable
        {
            [Fact]
            public void Should_throw_if_terraform_runner_was_not_found()
            {
                var fixture = new TerraformRefreshFixture();
                fixture.GivenDefaultToolDoNotExist();

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Terraform: Could not locate executable.", result.Message);
            }

            [Theory]
            [InlineData("/bin/tools/terraform/terraform.exe", "/bin/tools/terraform/terraform.exe")]
            [InlineData("/bin/tools/terraform/terraform", "/bin/tools/terraform/terraform")]
            public void Should_use_terraform_from_tool_path_if_provided(string toolPath, string expected)
            {
                var fixture = new TerraformRefreshFixture {Settings = {ToolPath = toolPath}};
                fixture.GivenSettingsToolPathExist();

                var result = fixture.Run();

                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_find_terraform_if_tool_path_not_provided()
            {
                var fixture = new TerraformRefreshFixture();

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_throw_if_process_has_a_non_zero_exit_code()
            {
                var fixture = new TerraformRefreshFixture();
                fixture.GivenProcessExitsWithCode(1);

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Terraform: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_find_linux_executable()
            {
                var fixture = new TerraformRefreshFixture(PlatformFamily.Linux);
                fixture.Environment.Platform.Family = PlatformFamily.Linux;


                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform", result.Path.FullPath);
            }

            [Fact]
            public void Should_set_refresh_parameter()
            {
                var fixture = new TerraformRefreshFixture();

                var result = fixture.Run();

                Assert.Contains("refresh", result.Args);
            }

            [Fact]
            public void Should_set_input_variables()
            {
                var fixture = new TerraformRefreshFixture
                {
                    Settings = new TerraformRefreshSettings
                    {
                        InputVariables = new Dictionary<string, string>
                        {
                            {"access_key", "foo"}, {"secret_key", "bar"}
                        }
                    }
                };
                var result = fixture.Run();

                Assert.Contains("-var \"access_key=foo\" -var \"secret_key=bar\"", result.Args);
            }

            [Fact]
            public void Should_set_input_variables_file()
            {
                var fixture = new TerraformRefreshFixture
                {
                    Settings = new TerraformRefreshSettings
                    {
                        InputVariablesFile = "./aws-creds.json",
                        InputVariables = new Dictionary<string, string>
                        {
                            {"access_key", "foo"},
                            {"secret_key", "bar"}
                        }
                    }
                };
                var result = fixture.Run();

                Assert.Contains("-var-file \"./aws-creds.json\" -var \"access_key=foo\" -var \"secret_key=bar\"",
                    result.Args);
            }
        }
    }
}