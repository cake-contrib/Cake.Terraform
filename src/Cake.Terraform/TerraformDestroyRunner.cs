using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
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

            if (!string.IsNullOrEmpty(settings.InputVarieablesFile))
            {
                builder.AppendSwitchQuoted("-var-file", $"{settings.InputVarieablesFile}");
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