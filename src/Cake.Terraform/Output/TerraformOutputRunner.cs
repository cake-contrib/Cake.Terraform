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

        private ProcessArgumentBuilder StandardArugments(TerraformOutputSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("output");

            if (settings.StatePath != null)
            {
                arguments.Append($"-state={settings.StatePath}");
            }

            return arguments;
        }
        
        public IEnumerable<string> Run(TerraformOutputSettings settings)
        {
            var arguments = StandardArugments(settings);
            
            if (settings.Json)
            {
                arguments.Append("-json");
            }

            IEnumerable<string> output = null;
            Run(settings, arguments, new ProcessSettings(), x =>
            {
                output = x.GetStandardOutput();
            });

            return output;
        }

        public string RunForSingle(TerraformOutputSettings settings, string outputName)
        {
            var arguments = StandardArugments(settings);

            arguments.Append(outputName);
            
            string output = null;
            Run(settings, arguments, new ProcessSettings(), x =>
            {
                var outputLines = x.GetStandardOutput();
                
                var builder = new StringBuilder();
                foreach (string line in outputLines)
                {
                    builder.AppendLine(line);
                }

                output = builder.ToString();
            });

            return output;
        }
    }
}