using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Terraform.Init;

namespace Cake.Terraform.Validate
{
    public class TerraformValidateRunner : TerraformRunner<TerraformValidateSettings>
    {
        public TerraformValidateRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformValidateSettings settings)
        {
            var builder = new ProcessArgumentBuilder().Append("validate");


            Run(settings, builder);
        }
    }

    public class TerraformValidateSettings : TerraformSettings
    {
    }
}
