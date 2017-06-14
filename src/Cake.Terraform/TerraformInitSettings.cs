using System.Collections.Generic;

namespace Cake.Terraform
{
    public class TerraformInitSettings : TerraformSettings
    {
        /// <summary>
        /// A set of backend config key-value overrides to be passed to `terraform init`
        /// <see>https://www.terraform.io/docs/commands/init.html#backend-config-value</see>
        /// </summary>
        public Dictionary<string, string> BackendConfigOverrides { get; set; }
    }
}