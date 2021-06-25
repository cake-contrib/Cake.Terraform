using System;
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

        private static string RemoveWhitespace(string x)
        {
            return x
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace(" ", "");
        }
        
        private void ConfirmSuccess(string output)
        {
            string outputNotFoundErrorString = RemoveWhitespace("The output variable requested could not be found in the state file. If you recently added this to your configuration, be sure to run `terraform apply`, since the state won't be updated with new output variables until that command is run.");

            if (RemoveWhitespace(output) == outputNotFoundErrorString)
            {
                throw new ArgumentException(output);
            }
        }

        public string Run(TerraformOutputSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("output")
                .Append("-no-color");

            if (settings.StatePath != null)
            {
                arguments.Append($"-state={settings.StatePath}");
            }

            if (settings.Raw)
            {
                arguments.Append("-raw");
            }
            else if (settings.Json)
            {
                arguments.Append("-json");
            }

            if (settings.OutputName != null)
            {
                arguments.Append(settings.OutputName);
            }

            var processSettings = new ProcessSettings
            {
                RedirectStandardOutput = true
            };
            
            string output = null;
            Run(settings, arguments, processSettings, x =>
            {
                var outputLines = x.GetStandardOutput().ToList();
                int lineCount = outputLines.Count();
                
                var builder = new StringBuilder();
                for (int i = 0; i < lineCount; i++)
                {
                    builder.Append(outputLines[i]);
                    
                    if (i < lineCount - 1)
                    {
                        builder.Append("\n"); // OS consistent
                    }
                }
                
                output = builder.ToString();
            });

            if (settings.ValidateToolOutput)
            {
                ConfirmSuccess(output);
            }
            
            return output;
        }
    }
}