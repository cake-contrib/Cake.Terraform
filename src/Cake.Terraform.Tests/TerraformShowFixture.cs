using Cake.Core;

namespace Cake.Terraform.Tests
{
    internal class TerraformShowFixture : TerraformFixture<TerraformShowSettings>
    {
        public TerraformShowFixture()
        {
        }

        public TerraformShowFixture(PlatformFamily platformFamily) : base(platformFamily)
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformShowRunner(FileSystem, Environment, ProcessRunner, Tools);
            ProcessRunner.Process.SetStandardOutput(new [] { "output" });
            tool.Run(Settings);
        }
    }
}