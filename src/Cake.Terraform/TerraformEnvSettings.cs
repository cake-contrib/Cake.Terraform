namespace Cake.Terraform
{
    public class TerraformEnvSettings : TerraformSettings
    {

        public enum EnvCommandType
        {
            Workspace,
            Env
        }

        public EnvCommandType EnvCommand { get; set; } = EnvCommandType.Workspace;
    }
}