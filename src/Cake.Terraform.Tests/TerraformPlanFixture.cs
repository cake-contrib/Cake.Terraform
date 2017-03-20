namespace Cake.Terraform.Tests
{
    internal class TerraformPlanFixture : TerraformFixture<TerraformPlanSettings>
    {
        public TerraformPlanFixture() : base("terraform.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformPlanRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}