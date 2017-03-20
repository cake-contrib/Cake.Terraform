namespace Cake.Terraform.Tests
{
    class TerraformApplyFixture : TerraformFixture<TerraformApplySettings>
    {
        public TerraformApplyFixture() : base("terraform.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformBuildRunner(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Run(Settings);
        }
    }
}