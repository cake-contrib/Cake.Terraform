namespace Cake.Terraform.EnvDelete
{
    public class TerraformEnvDeleteSettings : TerraformEnvSettings
    {
        public string Environment { get; set; }

        /// <summary>
        /// If set to true, then on Subcommand delete the state even if non-empty. Defaults to false.
        /// </summary>
        public bool Force { get; set; }
    }
}