using System.Collections.Generic;
using Cake.Core;
using Cake.Terraform.EnvList;

namespace Cake.Terraform.Tests
{
    public class TerraformOutputTests
    {
        class Fixture : TerraformFixture<TerraformEnvListSettings>
        {
            public Fixture(PlatformFamily platformFamily = PlatformFamily.Windows) : base(platformFamily) { }

            public IEnumerable<string> Environments { get; private set; } = new List<string>();

            protected override void RunTool()
            {
                ProcessRunner.Process.SetStandardOutput(new List<string>{ "default" });

                var tool = new TerraformEnvListRunner(FileSystem, Environment, ProcessRunner, Tools);

                Environments = tool.Run(Settings);
            }
        }
    }
}