using System.Collections.Generic;

namespace Cake.Terraform
{
    internal abstract class OutputFormatter
    {
        public abstract string FormatLines(IEnumerable<string> lines);
    }
}