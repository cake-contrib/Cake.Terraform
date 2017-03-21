using Cake.Core.IO;

namespace Cake.Terraform
{
    public class TerraformShowSettings : TerraformSettings
    {
        public FilePath OutFile { get; set; }
        public FilePath PlanFile { get; set; }
    }
}