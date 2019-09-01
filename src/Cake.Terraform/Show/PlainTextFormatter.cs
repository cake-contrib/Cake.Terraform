using System;
using System.Collections.Generic;

namespace Cake.Terraform.Show
{
    internal class PlainTextFormatter : OutputFormatter
    {
        public override string FormatLines(IEnumerable<string> lines)
        {
            return string.Join(Environment.NewLine, lines);
        }
    }
}