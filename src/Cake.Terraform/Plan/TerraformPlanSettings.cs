using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Terraform.Plan
{
    public class TerraformPlanSettings : TerraformSettings
    {
        public TerraformPlanSettings()
        {
            this.Input = true;
        }

        public FilePath OutFile { get; set; }

        public int Parallelism { get; set; }

        /// <summary>
        ///     Gets or sets the input variables. https://www.terraform.io/intro/getting-started/variables.html
        /// </summary>
        public Dictionary<string, string> InputVariables { get; set; }

        /// <summary>
        /// Variables file
        /// https://www.terraform.io/docs/configuration/variables.html#variable-files
        /// </summary>
        public string InputVariablesFile { get; set; }

        /// <summary>
        /// If set to true, generates a plan to destroy all the known resources
        /// </summary>
        public bool Destroy { get; set; }

        /// <summary>
        /// Ask for input for variables if not directly set.
        /// <see>https://www.terraform.io/docs/commands/plan.html#input-true</see>
        /// </summary>
        public bool Input { get; set; }
    }
}