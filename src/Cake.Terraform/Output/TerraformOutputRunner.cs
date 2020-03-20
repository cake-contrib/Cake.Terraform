using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform.Output
{
    public class TerraformOutputRunner : TerraformRunner<TerraformOutputSettings>
    {
        public TerraformOutputRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public string Run(TerraformOutputSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("output");

            if (settings.StatePath != null)
            {
                arguments.Append($"-state={settings.StatePath}");
            }

            if (settings.Json)
            {
                arguments.Append("-json");
            }

            if (settings.OutputName != null)
            {
                arguments.Append(settings.OutputName);
            }

            string output = null;
            Run(settings, arguments, new ProcessSettings(), x =>
            {
                var outputLines = x.GetStandardOutput();
                
                var builder = new StringBuilder();
                foreach (string line in outputLines)
                {
                    builder.Append(line);
                    builder.Append("\n"); // OS consistent
                }

                output = builder.ToString();
            });

            return output;
        }
    }
}