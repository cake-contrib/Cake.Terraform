using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Terraform.EnvList;
using Cake.Terraform.Output;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformOutputTests
    {
        class Fixture : TerraformFixture<TerraformOutputSettings>
        {
            public Fixture(PlatformFamily platformFamily = PlatformFamily.Windows) : base(platformFamily) { }

            public List<string> ToolOutput { get; set; } = new List<string> { "foo = 123", "bar = abc" };
            public string Outputs { get; private set; } = null;

            protected override void RunTool()
            {
                ProcessRunner.Process.SetStandardOutput(ToolOutput);
                
                var tool = new TerraformOutputRunner(FileSystem, Environment, ProcessRunner, Tools);

                Outputs = tool.Run(Settings);
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
                var fixture = new Fixture() {Settings = {ToolPath = toolPath}};
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
            public void Should_call_only_command_if_no_settings_specified()
            {
                var fixture = new Fixture();

                var result = fixture.Run();
                
                Assert.Equal("output -no-color", result.Args);
            }

            [Fact]
            public void Should_request_json_if_specified()
            {
                var fixture = new Fixture { Settings = new TerraformOutputSettings { Json = true } };

                var result = fixture.Run();
                
                Assert.Equal("output -no-color -json", result.Args);
            }
            
            [Fact]
            public void Should_request_specific_state_path_if_specified()
            {
                var fixture = new Fixture { Settings = new TerraformOutputSettings { StatePath = "some_path"} };

                var result = fixture.Run();
                
                Assert.Equal("output -no-color -state=some_path", result.Args);
            }
            
            [Fact]
            public void Should_request_particular_output_if_specified()
            {
                var fixture = new Fixture { Settings = new TerraformOutputSettings { OutputName = "some_output"} };

                var result = fixture.Run();
                
                Assert.Equal("output -no-color some_output", result.Args);
            }
            
            [Fact]
            public void Should_combine_output_lines_into_string()
            {
                var fixture = new Fixture();

                fixture.Run();
                
                Assert.Equal("foo = 123\nbar = abc\n", fixture.Outputs);
            }
            
            [Fact]
            public void Should_raise_exception_if_output_not_found()
            {
                var fixture = new Fixture
                {
                    ToolOutput = new List<string>
                    {
                        "The output variable requested could not be found in the state",
                        "file. If you recently added this to your configuration, be",
                        "sure to run `terraform apply`, since the state won't be updated",
                        "with new output variables until that command is run."
                    }
                };

                var exception = Assert.Throws<ArgumentException>(() => fixture.Run());
                Assert.Equal(
                    "The output variable requested could not be found in the state\nfile. If you recently added this to your configuration, be\nsure to run `terraform apply`, since the state won't be updated\nwith new output variables until that command is run.\n", 
                    exception.Message);
            }
        }
    }
}