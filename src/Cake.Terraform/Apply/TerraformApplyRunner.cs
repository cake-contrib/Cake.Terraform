using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform.Apply
{
    public class TerraformApplyRunner : TerraformRunner<TerraformApplySettings>
    {
        public TerraformApplyRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformApplySettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append("apply");

            // Order of AutoApprove and Plan are important.
            if (settings.AutoApprove)
            {
                builder.Append("-auto-approve");
            }

            // Use Plan if it exists.
            if (settings.Plan != null)
            {
                builder.Append(settings.Plan.FullPath);
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