using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
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

            if (!string.IsNullOrEmpty(settings.InputVariablesFile))
            {
                builder.AppendSwitchQuoted("-var-file", $"{settings.InputVariablesFile}");
            }

            if (settings.InputVariables != null)
            {
                foreach (var inputVariable in settings.InputVariables)
                {
                    builder.AppendSwitchQuoted("-var", $"{inputVariable.Key}={inputVariable.Value}");
                }
            }

            Run(settings, builder);
        }
    }
}