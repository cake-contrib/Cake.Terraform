namespace Cake.Terraform.Tests
{
    class TerraformInitFixture : TerraformFixture<TerraformInitSettings>
    {
        public TerraformInitFixture() : base("terraform.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformBuildRunner(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Run(Settings);
        }
    }
}