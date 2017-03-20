using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformPlanRunner : TerraformRunner<TerraformPlanSettings>
    {
        public TerraformPlanRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public bool HasChanges { get; private set; }

        public void Run(TerraformPlanSettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append("plan")
                .Append($"-out={settings.OutFile}")
                .Append("-detailed-exitcode");

            if (settings.Parallelism > 0)
            {
                builder = builder.Append($"-parallelism={settings.Parallelism}");

            }

            Run(settings, builder);
        }
    }
}