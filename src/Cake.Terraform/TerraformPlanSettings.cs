using Cake.Core.IO;

namespace Cake.Terraform
{
    public class TerraformPlanSettings : TerraformSettings
    {
        public FilePath OutFile { get; set; }
        public int Parallelism { get; set; }
    }
}