using Cake.Core.IO;

namespace Cake.Terraform
{
    public class TerraformApplySettings : TerraformSettings
    {
        public int Parallelism { get; set; }
        public FilePath Plan { get; set; }
    }
}