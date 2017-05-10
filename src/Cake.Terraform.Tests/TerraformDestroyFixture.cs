using Cake.Core;

namespace Cake.Terraform.Tests
{
    class TerraformDestroyFixture : TerraformFixture<TerraformDestroySettings>
    {
        public TerraformDestroyFixture()
        {
        }

        public TerraformDestroyFixture(PlatformFamily platformFamily) : base(platformFamily)
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformDestroyRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}