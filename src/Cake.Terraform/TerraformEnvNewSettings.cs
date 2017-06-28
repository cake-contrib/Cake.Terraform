using System;
using Cake.Core.IO;
using Cake.Terraform;

namespace ANW.CakeTools.Terraform
{
    public class TerraformEnvNewSettings : TerraformSettings
    {
        public string Environment { get; set; }
    }
}