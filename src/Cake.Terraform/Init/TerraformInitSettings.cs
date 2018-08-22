using System.Collections.Generic;

namespace Cake.Terraform.Init
{
    public class TerraformInitSettings : TerraformSettings
    {
        /// <summary>
        /// A set of backend config key-value overrides to be passed to `terraform init`
        /// <see>https://www.terraform.io/docs/commands/init.html#backend-config-value</see>
        /// </summary>
        public Dictionary<string, string> BackendConfigOverrides { get; set; }
        
        /// <summary>
        /// Reconfigure the backend, ignoring any saved configuration.
        /// <see>https://www.terraform.io/docs/commands/init.html#reconfigure</see>
        /// </summary>
        public bool ForceReconfigure { get; set; }
        
        /// <summary>
        /// Suppress prompts about copying state data. This is equivalent to providing
        /// a "yes" to all confirmation prompts.
        /// <see>https://www.terraform.io/docs/commands/init.html#force-copy</see>
        /// </summary>
        public bool ForceCopy { get; set; }
    }
}
