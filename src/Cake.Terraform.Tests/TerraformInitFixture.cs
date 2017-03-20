namespace Cake.Terraform.Tests
{
    class TerraformInitFixture : TerraformFixture<TerraformInitSettings>
    {
        protected override void RunTool()
        {
            var tool = new TerraformInitRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}