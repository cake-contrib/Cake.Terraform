using Cake.Core;
using Cake.Core.IO;

namespace Cake.Terraform
{
    public interface ITerraformToolResolver
    {
        FilePath ResolvePath();
    }

    public class TerraformToolResolver : ITerraformToolResolver
    {

        public TerraformToolResolver(IFileSystem fileSystem, ICakeEnvironment environment)
        {

        }

        public FilePath ResolvePath()
        {
            return null;
        }
    }
}