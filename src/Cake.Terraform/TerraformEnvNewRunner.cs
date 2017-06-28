using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Terraform;

namespace ANW.CakeTools.Terraform
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
                    .Append("env")
                    .Append("new")
                    .Append(newSettings.Environment);

            Run(newSettings, builder);
        }
    }
}