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
            Run(settings, builder);
        }
    }
}