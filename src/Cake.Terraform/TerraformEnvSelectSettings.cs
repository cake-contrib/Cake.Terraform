using System;
using Cake.Core.IO;
using Cake.Terraform;

namespace ANW.CakeTools.Terraform
{
    public class TerraformEnvSelectSettings : TerraformSettings
    {
        public string Environment { get; set; }
    }
}