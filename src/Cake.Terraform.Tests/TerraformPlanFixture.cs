namespace Cake.Terraform.Tests
{
    internal class TerraformPlanFixture : TerraformFixture<TerraformPlanSettings>
    {
        public TerraformPlanFixture() : base("terraform.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformBuildRunner(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Run(Settings);
        }
    }
}