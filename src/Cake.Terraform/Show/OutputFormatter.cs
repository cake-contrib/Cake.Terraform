using System.Collections.Generic;

namespace Cake.Terraform.Show
{
    internal abstract class OutputFormatter
    {
        public abstract string FormatLines(IEnumerable<string> lines);
    }
}