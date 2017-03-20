using Cake.Core.Tooling;

namespace Cake.Terraform.Tests
{
    public abstract class TerraformFixture<TSettings> : Testing.Fixtures.ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected TerraformFixture(string toolFilename) : base(toolFilename)
        {
        }
    }
}