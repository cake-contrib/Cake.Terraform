using System.Collections.Generic;
using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformPlanTests
    {
        public class TheExecutable
        {
            [Fact]
            public void Should_throw_if_terraform_runner_was_not_found()
            {
                var fixture = new TerraformPlanFixture();
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
                var fixture = new TerraformPlanFixture {Settings = {ToolPath = toolPath}};
                fixture.GivenSettingsToolPathExist();

                var result = fixture.Run();

                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_find_terraform_if_tool_path_not_provided()
            {
                var fixture = new TerraformPlanFixture();

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_find_linux_executable()
            {
                var fixture = new TerraformPlanFixture(PlatformFamily.Linux);
                fixture.Environment.Platform.Family = PlatformFamily.Linux;


                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform", result.Path.FullPath);
            }

            [Fact]
            public void Should_not_have_changes_if_process_has_exit_code_zero()
            {
                var fixture = new TerraformPlanFixture();
                fixture.GivenProcessExitsWithCode(0);

                var result = fixture.Run();

                Assert.False(fixture.HasChanges);
            }

            [Fact]
            public void Should_throw_if_process_has_exit_code_one()
            {
                var fixture = new TerraformPlanFixture();
                fixture.GivenProcessExitsWithCode(1);

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Terraform: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_have_changes_if_process_has_exit_code_two()
            {
                var fixture = new TerraformPlanFixture();
                fixture.GivenProcessExitsWithCode(2);

                var result = fixture.Run();

                Assert.True(fixture.HasChanges);
            }

            [Fact]
            public void Should_set_plan_parameter()
            {
                var fixture = new TerraformPlanFixture();

                var result = fixture.Run();

                Assert.Contains("plan", result.Args);
            }

            [Fact]
            public void Should_set_detailed_exit_code()
            {
                var fixture = new TerraformPlanFixture();
                var result = fixture.Run();

                Assert.Contains("-detailed-exitcode", result.Args);
            }

            [Fact]
            public void Should_set_parallelism()
            {
                var fixture = new TerraformPlanFixture();
                fixture.Settings = new TerraformPlanSettings {Parallelism = 10};
                var result = fixture.Run();

                Assert.Contains("-parallelism=10", result.Args);
            }

            [Fact]
            public void Should_not_set_parallelism_if_zero()
            {
                var fixture = new TerraformPlanFixture();
                var result = fixture.Run();

                Assert.DoesNotContain("-parallelism", result.Args);
            }

            [Fact]
            public void Should_set_input_variables()
            {
                var fixture = new TerraformPlanFixture();
                fixture.Settings = new TerraformPlanSettings
                {
                    InputVariables = new Dictionary<string, string>
                    {
                        { "access_key", "foo" },
                        { "secret_key", "bar" }
                    }
                };
                var result = fixture.Run();

                Assert.Contains("-var \"access_key=foo\" -var \"secret_key=bar\"", result.Args);
            }
        }
    }
}