using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform.EnvNew
{
    public class TerraformEnvNewRunner : TerraformRunner<TerraformEnvNewSettings>
    {
        public TerraformEnvNewRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformEnvNewSettings settings)
        {
            if (string.IsNullOrEmpty(settings.Environment))
            {
                throw new ArgumentException(nameof(settings.Environment));
            }

            var builder = new ProcessArgumentBuilder()
                    .Append(settings.EnvCommand.ToString().ToLower())
                    .Append("new")
                    .Append(settings.Environment);

            Run(settings, builder);
        }
    }
}