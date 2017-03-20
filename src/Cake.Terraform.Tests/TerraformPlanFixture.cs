using Cake.Core;

namespace Cake.Terraform.Tests
{
    internal class TerraformPlanFixture : TerraformFixture<TerraformPlanSettings>
    {
        public TerraformPlanFixture()
        {
        }

        public TerraformPlanFixture(PlatformFamily platformFamily) : base(platformFamily)
        {
        }

        public bool HasChanges { get; set; }

        protected override void RunTool()
        {
            var tool = new TerraformPlanRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
            HasChanges = tool.HasChanges;
        }
    }
}