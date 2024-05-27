using System;
using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Terraform.Refresh
{
    public class TerraformRefreshSettings : TerraformSettings
    {
        public FilePath Plan { get; set; }

        /// <summary>
        ///     Gets or sets the input variables. https://www.terraform.io/intro/getting-started/variables.html
        /// </summary>
        public Dictionary<string, string> InputVariables { get; set; }
        
        [Obsolete("use InputVariablesFiles instead.")]
        public string InputVariablesFile { get; set; }

        /// <summary>
        /// Variables file
        /// https://www.terraform.io/docs/configuration/variables.html#variable-files
        /// </summary>
        public ICollection<string> InputVariablesFiles { get; } = new List<string>();
    }
}