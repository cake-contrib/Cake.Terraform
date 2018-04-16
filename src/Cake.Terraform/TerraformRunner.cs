using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public abstract class TerraformRunner<TTerraformSettings> : Tool<TTerraformSettings> where TTerraformSettings : TerraformSettings
    {
        private readonly ICakePlatform _platform;

        protected TerraformRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _platform = environment.Platform;
        }

        protected override string GetToolName()
        {
            return "Terraform";
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { _platform.IsUnix() ? "terraform" : "terraform.exe" };
        }
    }
}