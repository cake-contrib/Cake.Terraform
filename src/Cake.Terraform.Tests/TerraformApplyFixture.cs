using Cake.Core;

namespace Cake.Terraform.Tests
{
    class TerraformApplyFixture : TerraformFixture<TerraformApplySettings>
    {
        public TerraformApplyFixture()
        {
        }

        public TerraformApplyFixture(PlatformFamily platformFamily) : base(platformFamily)
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformApplyRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}