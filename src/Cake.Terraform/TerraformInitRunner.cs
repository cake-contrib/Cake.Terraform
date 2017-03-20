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
            var builder = new ProcessArgumentBuilder().Append("init");
            Run(settings, builder);
        }
    }
}