using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Cake.Terraform.Show
{
    internal class HtmlFormatter : OutputFormatter
    {
        readonly Dictionary<string,string> _styles = new Dictionary<string,string> {
            { "0", "normal"},
            { "1", "bold"},
            { "30", "black"},
            { "31", "red"},
            { "32", "green"},
            { "33", "yellow"},
            { "34", "blue"},
            { "35", "magenta"},
            { "36", "cyan"},
            { "37", "white"},
            { "90", "grey"}
        };

        private readonly string _header = @"
<!doctype html>
<html><head><meta charset=""utf-8"" />
      <style>
        .bold {
          font-weight: bold;
        }
        .black {
          color: black;
        }
        .red {
          color: red;
        }
        .green {
          color: green;
        }
        .yellow {
          color: #d6b300;
        }
        .blue {
          color: blue;
        }
        .magenta {
          color: magenta;
        }
        .cyan {
          color: cyan;
        }
        .white {
          color: white;
        }
        .grey {
          color: grey;
        }
      </style>
</head><body><pre><code>
";

        private readonly string _footer = @"
</code></pre></body></html>
";

        public override string FormatLines(IEnumerable<string> lines)
        {
            var outputBuilder = new StringBuilder();
            outputBuilder.AppendLine(_header);

            var regex = new Regex(@"(.*)\e\[(3[0-7]|90|1)m(.*)");
            foreach(var line in lines.Select(x => new Regex(@"\e\[0m").Replace(x, "").Replace("\\r","\r").Replace("\\n", "\n")))
            {
                var match = regex.Match(line);
                if(match.Success) {
                    var styledLine = $"{WebUtility.HtmlEncode(match.Groups[1].Value)}<span class=\"{_styles[match.Groups[2].Value]}\">{WebUtility.HtmlEncode(match.Groups[3].Value)}</span>";
                    outputBuilder.AppendLine(styledLine);
                }
                else
                {
                    outputBuilder.AppendLine(WebUtility.HtmlEncode(line));
                }
            }

            outputBuilder.AppendLine(_footer);

            return outputBuilder.ToString();
        }
    }
}