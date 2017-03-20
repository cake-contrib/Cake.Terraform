namespace Cake.Terraform.Tests
{
    class TerraformApplyFixture : TerraformFixture<TerraformApplySettings>
    {
        protected override void RunTool()
        {
            var tool = new TerraformApplyRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}