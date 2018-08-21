using Cake.Core;

namespace Cake.Terraform.Tests
{
    class TerraformRefreshFixture : TerraformFixture<TerraformRefreshSettings>
    {
        public TerraformRefreshFixture()
        {
        }

        public TerraformRefreshFixture(PlatformFamily platformFamily) : base(platformFamily)
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformRefreshRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}