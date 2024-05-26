﻿using System.Collections.Generic;
using Cake.Core;
using Cake.Terraform.Init;
using Cake.Testing;
using Xunit;

namespace Cake.Terraform.Tests
{
    public class TerraformInitTests
    {
        class Fixture : TerraformFixture<TerraformInitSettings>
        {
            public Fixture(PlatformFamily platformFamily = PlatformFamily.Windows) : base(platformFamily)
            {
            }

            protected override void RunTool()
            {
                var tool = new TerraformInitRunner(FileSystem, Environment, ProcessRunner, Tools);
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
            public void Should_set_init_parameter()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.Contains("init", result.Args);
            }

            [Fact]
            public void Should_pass_backend_config_overrides()
            {
                var fixture = new Fixture();

                fixture.Settings = new TerraformInitSettings
                {
                    BackendConfigOverrides = new Dictionary<string, string>
                    {
                        { "key", "value" },
                        { "foo", "bar" },
                    }
                };

                var result = fixture.Run();

                Assert.Contains("-backend-config \"key=value\"", result.Args);
                Assert.Contains("-backend-config \"foo=bar\"", result.Args);
            }
            
            [Fact]
            public void Should_omit_reconfigure_flag_by_default()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.DoesNotContain("-reconfigure", result.Args);
            }
            
            [Fact]
            public void Should_include_reconfigure_flag_when_setting_is_true()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformInitSettings
                    {
                        ForceReconfigure = true
                    }
                };

                var result = fixture.Run();

                Assert.Contains("-reconfigure", result.Args);
            }
            
            [Fact]
            public void Should_omit_force_copy_flag_by_default()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.DoesNotContain("-force-copy", result.Args);
            }
            
            [Fact]
            public void Should_include_force_copy_flag_when_setting_is_true()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformInitSettings
                    {
                        ForceCopy = true
                    }
                };

                var result = fixture.Run();

                Assert.Contains("-force-copy", result.Args);
            }

            [Fact]
            public void Should_omit_input_flag_by_default()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.DoesNotContain("-input", result.Args);
            }

            [Fact]
            public void Should_include_input_flag_when_setting_is_false()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformInitSettings
                    {
                        Input = false
                    }
                };

                var result = fixture.Run();

                Assert.Contains("-input", result.Args);
            }

            [Fact]
            public void Should_omit_backend_flag_by_default()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.DoesNotContain("-backend", result.Args);
            }

            [Fact]
            public void Should_include_backend_flag_when_setting_is_false()
            {
                var fixture = new Fixture
                {
                    Settings = new TerraformInitSettings
                    {
                        Backend = false
                    }
                };

                var result = fixture.Run();

                Assert.Contains("-backend", result.Args);
            }
        }
    }
}