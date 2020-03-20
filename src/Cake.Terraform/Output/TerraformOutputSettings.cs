using System;

namespace Cake.Terraform.Output
{
    public class TerraformOutputSettings : TerraformSettings
    {
        public string Name { get; set; }
        public bool Json { get; set; }
        public string StatePath { get; set; }
    }
}