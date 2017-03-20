namespace Cake.Terraform.Tests
{
    class TerraformApplyFixture : TerraformFixture<TerraformApplySettings>
    {
        public TerraformApplyFixture() : base("terraform.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformApplyRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}