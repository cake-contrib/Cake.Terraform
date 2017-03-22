using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformShowRunner : TerraformRunner<TerraformShowSettings>
    {
        private readonly Dictionary<OutputFormat, OutputFormatter> _formatters = new Dictionary<OutputFormat, OutputFormatter>
        {
            {OutputFormat.PlainText, new PlainTextFormatter()},
            {OutputFormat.Html, new HtmlFormatter()}
        };

        public TerraformShowRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(TerraformShowSettings settings)
        {
            if (settings.PlanFile == null)
            {
                throw new ArgumentNullException(nameof(settings.PlanFile));
            }

            var arguments = new ProcessArgumentBuilder()
                .Append("show")
                .Append(settings.PlanFile.FullPath);

            if (settings.OutputFormat == OutputFormat.PlainText)
            {
                arguments.Append("-no-color");
            }

            var processSettings = new ProcessSettings();
            if (settings.OutFile != null)
            {
                processSettings.RedirectStandardOutput = true;
            }

            Run(settings, arguments, processSettings, x =>
            {
                if (settings.OutFile != null)
                {
                    OutputFormatter formatter;
                    if (!_formatters.TryGetValue(settings.OutputFormat, out formatter))
                    {
                        formatter = _formatters[OutputFormat.PlainText];
                    }

                    File.WriteAllText(settings.OutFile.FullPath, formatter.FormatLines(x.GetStandardOutput()));
                }
            });
        }
    }
}