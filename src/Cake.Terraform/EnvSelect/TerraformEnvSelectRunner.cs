using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform.EnvSelect
{
    public class TerraformEnvSelectRunner : TerraformRunner<TerraformEnvSelectSettings>
    {
        public TerraformEnvSelectRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformEnvSelectSettings settings)
        {
            if (string.IsNullOrEmpty(settings.Environment))
            {
                throw new ArgumentException(nameof(settings.Environment));
            }

            var builder = new ProcessArgumentBuilder()
                    .Append(settings.EnvCommand.ToString().ToLower())
                    .Append("select")
                    .Append(settings.Environment);

            Run(settings, builder);
        }
    }
}