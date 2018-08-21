using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformRefreshRunner : TerraformRunner<TerraformRefreshSettings>
    {
        public TerraformRefreshRunner(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformRefreshSettings settings)
        {
            var builder = new ProcessArgumentBuilder().Append("refresh");

            // Use Plan if it exists.
            if (settings.Plan != null)
            {
                builder.Append(settings.Plan.FullPath);
            }

            if (!string.IsNullOrEmpty(settings.InputVariablesFile))
            {
                builder.AppendSwitchQuoted("-var-file", $"{settings.InputVariablesFile}");
            }

            builder = settings.InputVariables?.Aggregate(builder,
                          (b, input) => b.AppendSwitchQuoted("-var", $"{input.Key}={input.Value}"))
                      ?? builder;

            Run(settings, builder);
        }
    }
}