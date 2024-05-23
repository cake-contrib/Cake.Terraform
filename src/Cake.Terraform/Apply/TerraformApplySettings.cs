﻿using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Terraform.Apply
{
    public class TerraformApplySettings : TerraformSettings
    {
        public TerraformApplySettings()
        {
            this.Input = true;
        }

        public int Parallelism { get; set; }

        public FilePath Plan { get; set; }

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
        /// Skip interactive approval of plan before applying.
        /// https://www.terraform.io/docs/commands/apply.html#auto-approve
        /// </summary>
        public bool AutoApprove { get; set; }

        /// <summary>
        /// Ask for input for variables if not directly set.
        /// <see>https://www.terraform.io/docs/commands/apply.html#input-true</see>
        /// </summary>
        public bool Input { get; set; }
    }
}