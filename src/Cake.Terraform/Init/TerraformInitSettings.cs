using System.Collections.Generic;

namespace Cake.Terraform.Init
{
    public class TerraformInitSettings : TerraformSettings
    {
        public TerraformInitSettings()
        {
            this.Input = true;
            this.Backend = true;
        }

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

        /// <summary>
        /// Ask for input if necessary. If false, will error if input was required.
        /// <see>https://www.terraform.io/docs/commands/init.html#input-true</see>
        /// </summary>
        public bool Input { get; set; }

        /// <summary>
        /// Configure the backend for this configuration.
        /// <see>https://www.terraform.io/docs/commands/init.html#backend-initialization</see>
        /// </summary>
        public bool Backend { get; set; }
    }
}
