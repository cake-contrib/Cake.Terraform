using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformEnvNewRunner : TerraformRunner<TerraformEnvNewSettings>
    {
        public TerraformEnvNewRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformEnvNewSettings newSettings)
        {
            if (string.IsNullOrEmpty(newSettings.Environment))
            {
                throw new ArgumentException(nameof(newSettings.Environment));
            }

            var builder =
                new ProcessArgumentBuilder()
                    .Append("workspace")
                    .Append("new")
                    .Append(newSettings.Environment);

            Run(newSettings, builder);
        }
    }
}