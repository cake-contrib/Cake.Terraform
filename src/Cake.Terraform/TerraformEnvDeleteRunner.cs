using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformEnvDeleteRunner : TerraformRunner<TerraformEnvDeleteSettings>
    {
        public TerraformEnvDeleteRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }
        public void Run(TerraformEnvDeleteSettings settings)
        {
            var builder =
                new ProcessArgumentBuilder()
                    .Append("workspace");

            builder = builder.Append("delete");

            if (settings.Force)
            {
                builder = builder.Append("-force");
            }

            Run(settings, builder);
        }
    }
}