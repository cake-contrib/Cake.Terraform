using Cake.Core;
using Cake.Core.Tooling;

namespace Cake.Terraform.Tests
{
    public abstract class TerraformFixture<TSettings> : Testing.Fixtures.ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected TerraformFixture(PlatformFamily platformFamily = PlatformFamily.Windows)
            : base(platformFamily == PlatformFamily.Windows ? "terraform.exe" : "terraform")
        {
            Environment.Platform.Family = platformFamily;
        }
    }
}