using System.IO;
using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformShowTests
    {
        public class TheExecutable
        {
            [Fact]
            public void Should_throw_if_terraform_runner_was_not_found()
            {
                var fixture = new TerraformShowFixture();
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
                var fixture = new TerraformShowFixture {Settings = {ToolPath = toolPath}};
                fixture.GivenSettingsToolPathExist();

                var result = fixture.Run();

                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_find_terraform_if_tool_path_not_provided()
            {
                var fixture = new TerraformShowFixture();

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_find_linux_executable()
            {
                var fixture = new TerraformShowFixture(PlatformFamily.Linux);

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform", result.Path.FullPath);
            }

            [Fact]
            public void Should_set_show_parameter()
            {
                var fixture = new TerraformShowFixture();

                var result = fixture.Run();

                Assert.Contains("show", result.Args);
            }

            [Fact]
            public void Should_set_plan_file_parameter()
            {
                var fixture = new TerraformShowFixture { Settings = { PlanFile = "./input/myplan.plan" }};

                var result = fixture.Run();

                Assert.Contains(fixture.Settings.PlanFile.FullPath, result.Args);
            }

            [Fact]
            public void Should_redirect_stdout_to_file_if_set()
            {
                var fixture = new TerraformShowFixture {Settings = { OutFile = "./output.txt" }};

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardOutput);
                Assert.Equal(fixture.ProcessRunner.Process.GetStandardOutput(), File.ReadAllLines(fixture.Settings.OutFile.FullPath));
            }
        }
    }
}