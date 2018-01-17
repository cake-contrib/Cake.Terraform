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
            var builder = new ProcessArgumentBuilder().Append("apply");

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

            if (settings.Parallelism != default(int))
            {
                builder.AppendSwitch("-parallelism", "=", settings.Parallelism.ToString());
            }

            if (settings.Plan != null)
            {
                builder.AppendQuoted(settings.Plan.ToString());
            }

            Run(settings, builder);
        }
    }
}