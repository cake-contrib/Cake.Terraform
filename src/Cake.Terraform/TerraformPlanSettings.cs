namespace Cake.Terraform
{
    public class TerraformPlanSettings : TerraformSettings
    {
        public string OutFile { get; set; }
        public int Parallelism { get; set; }
    }
}