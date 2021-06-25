namespace Cake.Terraform.Output
{
    public class TerraformOutputSettings : TerraformSettings
    {
        public string OutputName { get; set; }
        public bool Json { get; set; }
        public bool Raw { get; set; }
        public string StatePath { get; set; }
        public bool ValidateToolOutput { get; set; } = true;
    }
}