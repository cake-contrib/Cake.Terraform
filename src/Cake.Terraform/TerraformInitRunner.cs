using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformInitRunner : TerraformRunner<TerraformInitSettings>
    {
        public TerraformInitRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformInitSettings settings)
        {
            var builder =
                new ProcessArgumentBuilder()
                    .Append("init");

            if (settings.BackendConfigOverrides != null)
            {
                foreach (var pair in settings.BackendConfigOverrides)
                {
                    // https://www.terraform.io/docs/commands/init.html#backend-config-value
                    builder.AppendSwitchQuoted("-backend-config", $"{pair.Key}={pair.Value}");
                }
            }

            if (settings.ForceCopy)
            {
                builder.Append("-force-copy");
            }

            if (settings.ForceReconfigure)
            {
                builder.Append("-reconfigure");
            }

            Run(settings, builder);
        }
    }
}