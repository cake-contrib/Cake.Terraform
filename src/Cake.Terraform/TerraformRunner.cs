using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Terraform
{
    public class TerraformBuildRunner : Tool<TerraformSettings>
    {
        public bool HasChanges { get; private set; }

        public TerraformBuildRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ITerraformToolResolver resolver) : base(fileSystem, environment, processRunner, tools)
        {
        }

        protected override string GetToolName()
        {
            return "Terraform";
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "terraform.exe" };
        }

        public void Run(TerraformSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(settings));

        }

        protected override void ProcessExitCode(int exitCode)
        {
            if (exitCode == 2)
            {
                HasChanges = true;
                return;
            }
            base.ProcessExitCode(exitCode);
        }

        private ProcessArgumentBuilder GetArguments(TerraformSettings settings)
        {
            var builder = new ProcessArgumentBuilder();
            if (settings is TerraformPlanSettings)
            {
                var planSettings = settings as TerraformPlanSettings;
                builder= builder.Append("plan")
                    .Append($"-out={planSettings.OutFile}")
                    .Append("-detailed-exitcode");

                if (planSettings.Parallelism > 0)
                {
                    builder = builder.Append($"-parallelism={planSettings.Parallelism}");

                }
                return builder;
            }
            else if (settings is TerraformInitSettings)
            {
                builder = builder.Append("init");
                return builder;
            }
            else if (settings is TerraformApplySettings)
            {
                builder = builder.Append("apply");
                return builder;
            }
            throw new NotImplementedException();
        }
    }
}