using System;
using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformInitTests
    {
        public class TheExecutable
        {
            [Fact]
            public void Should_throw_if_terraform_runner_was_not_found()
            {
                var fixture = new TerraformInitFixture();
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
                var fixture = new TerraformInitFixture() {Settings = {ToolPath = toolPath}};
                fixture.GivenSettingsToolPathExist();

                var result = fixture.Run();

                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_find_terraform_if_tool_path_not_provided()
            {
                var fixture = new TerraformInitFixture();

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_throw_if_process_has_a_non_zero_exit_code()
            {
                var fixture = new TerraformPlanFixture();
                fixture.GivenProcessExitsWithCode(1);

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Terraform: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_set_plan_parameter()
            {
                var fixture = new TerraformInitFixture();

                var result = fixture.Run();

                Assert.Contains("init", result.Args);
            }
        }
    }
}