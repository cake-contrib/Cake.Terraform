using System;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformShowRunner : TerraformRunner<TerraformShowSettings>
    {
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

            var processSettings = new ProcessSettings();
            if (settings.OutFile != null)
            {
                processSettings.RedirectStandardOutput = true;
            }

            Run(settings, arguments, processSettings, x =>
            {
                if(settings.OutFile != null)
                    File.WriteAllLines(settings.OutFile.FullPath, x.GetStandardOutput());
            });
        }
    }
}