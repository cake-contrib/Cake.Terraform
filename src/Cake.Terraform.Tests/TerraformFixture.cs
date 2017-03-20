using Cake.Core.Diagnostics;
using Cake.Core.Tooling;
using NSubstitute;

namespace Cake.Terraform.Tests
{
    public abstract class TerraformFixture<TSettings> : Testing.Fixtures.ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {

        public ICakeLog Log { get; set; }
        public ITerraformToolResolver Resolver { get; set; }

        protected TerraformFixture(string toolFilename) : base(toolFilename)
        {
            Resolver = Substitute.For<ITerraformToolResolver>();
        }
    }
}