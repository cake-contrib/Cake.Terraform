using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Terraform;

namespace ANW.CakeTools.Terraform
{
    public class TerraformEnvSelectRunner : TerraformRunner<TerraformEnvSelectSettings>, ITerraformEnvSelectRunner
    {
        public TerraformEnvSelectRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }
        public void Run(TerraformEnvSelectSettings settings)
        {
            var builder =
                new ProcessArgumentBuilder()
                    .Append("env");

            builder = builder.Append("select");

            if (string.IsNullOrEmpty(settings.Environment))
            {
                throw new ArgumentException(nameof(settings.Environment));
            }

            builder = builder.Append(settings.Environment);

            Run(settings, builder);
        }
    }
}