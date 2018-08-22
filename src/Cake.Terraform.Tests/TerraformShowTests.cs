using System.IO;
using Cake.Core;
using Cake.Terraform.Show;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformShowTests
    {
        class Fixture : TerraformFixture<TerraformShowSettings>
        {
            public Fixture(PlatformFamily platformFamily = PlatformFamily.Windows) : base(platformFamily) { }

            protected override void RunTool()
            {
                var tool = new TerraformShowRunner(FileSystem, Environment, ProcessRunner, Tools);
                Settings.PlanFile = "my.plan";
                ProcessRunner.Process.SetStandardOutput(new[] { "output" });
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
            public void Should_find_linux_executable()
            {
                var fixture = new Fixture(PlatformFamily.Linux);

                var result = fixture.Run();

                Assert.Equal("/Working/tools/terraform", result.Path.FullPath);
            }

            [Fact]
            public void Should_set_show_parameter()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.Contains("show", result.Args);
            }

            [Fact]
            public void Should_set_plan_file_parameter()
            {
                var fixture = new Fixture { Settings = { PlanFile = "./input/myplan.plan" }};

                var result = fixture.Run();

                Assert.Contains(fixture.Settings.PlanFile.FullPath, result.Args);
            }

            [Fact]
            public void Should_redirect_stdout_to_file_if_set()
            {
                var fixture = new Fixture {Settings = { OutFile = "./output.txt" }};

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardOutput);
                Assert.Equal(fixture.ProcessRunner.Process.GetStandardOutput(), File.ReadAllLines(fixture.Settings.OutFile.FullPath));
            }
        }
    }
}