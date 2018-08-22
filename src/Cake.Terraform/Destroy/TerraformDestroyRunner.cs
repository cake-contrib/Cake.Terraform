using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform.Destroy
{
    public class TerraformDestroyRunner : TerraformRunner<TerraformDestroySettings>
    {
        public TerraformDestroyRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformDestroySettings settings)
        {
            var builder = new ProcessArgumentBuilder().Append("destroy");

            if (settings.Force)
            {
                builder = builder.Append("-force");
            }

            if (!string.IsNullOrWhiteSpace(settings.InputVariablesFile))
            {
                builder.AppendSwitchQuoted("-var-file", $"{settings.InputVariablesFile}");
            }

            foreach (var inputVariable in settings.InputVariables ?? new Dictionary<string, string>())
            {
                builder.AppendSwitchQuoted("-var", $"{inputVariable.Key}={inputVariable.Value}");
            }

            Run(settings, builder);
        }
    }
}