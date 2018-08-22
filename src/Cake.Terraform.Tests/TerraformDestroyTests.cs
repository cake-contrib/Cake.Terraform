using System.Collections.Generic;
using Cake.Core;
using Cake.Terraform.Destroy;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformDestroyTests
    {
        class Fixture : TerraformFixture<TerraformDestroySettings>
        {
            public Fixture(PlatformFamily platformFamily = PlatformFamily.Windows) : base(platformFamily) { }

            protected override void RunTool()
            {
                var tool = new TerraformDestroyRunner(FileSystem, Environment, ProcessRunner, Tools);
                tool.Run(Settings);
            }
        }

        public class TheExecutable
        {
            [Fact]
            public void Should_throw_if_terraform_runner_was_not_found()
            {
                var fixture = new Fixture();
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
                var fixture = new Fixture {Settings = {ToolPath = toolPath}};
                fixture.GivenSettingsToolPathExist();

                var result = fixture.Run();

                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_find_terraform_if_tool_path_not_provided()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_throw_if_process_has_a_non_zero_exit_code()
            {
                var fixture = new Fixture();
                fixture.GivenProcessExitsWithCode(1);

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Terraform: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_find_linux_executable()
            {
                var fixture = new Fixture(PlatformFamily.Linux);
                fixture.Environment.Platform.Family = PlatformFamily.Linux;


                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform", result.Path.FullPath);
            }

            [Fact]
            public void Should_set_destroy_parameter()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.Contains("destroy", result.Args);
            }

            [Fact]
            public void Should_set_force_flag_when_set_to_true()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformDestroySettings
                    {
                        Force = true
                    }
                };
                var result = fixture.Run();

                Assert.Contains("-force", result.Args);
            }

            [Fact]
            public void Should_set_input_variables()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformDestroySettings
                    {
                        InputVariables = new Dictionary<string, string>
                        {
                            {"access_key", "foo"},
                            {"secret_key", "bar"}
                        }
                    }
                };
                var result = fixture.Run();

                Assert.Contains("-var \"access_key=foo\" -var \"secret_key=bar\"", result.Args);
            }

            [Fact]
            public void Should_set_input_variables_file()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformDestroySettings
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

                Assert.Contains("-var-file \"./aws-creds.json\" -var \"access_key=foo\" -var \"secret_key=bar\"", result.Args);
            }
        }
    }
}