namespace Cake.Terraform.Tests
{
    class TerraformInitFixture : TerraformFixture<TerraformInitSettings>
    {
        public TerraformInitFixture() : base("terraform.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new TerraformInitRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}