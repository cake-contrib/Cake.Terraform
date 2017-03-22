using System;
using System.Collections.Generic;

namespace Cake.Terraform
{
    internal class PlainTextFormatter : OutputFormatter
    {
        public override string FormatLines(IEnumerable<string> lines)
        {
            return string.Join(Environment.NewLine, lines);
        }
    }
}