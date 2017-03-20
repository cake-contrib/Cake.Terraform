using Cake.Core;

namespace Cake.Terraform.Tests
{
    class TerraformInitFixture : TerraformFixture<TerraformInitSettings>
    {
        public TerraformInitFixture()
        {
        }

        public TerraformInitFixture(PlatformFamily platformFamily) : base(platformFamily)
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformInitRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}