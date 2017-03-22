using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cake.Terraform
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
</head><body><ul>";

        private readonly string _footer = @"
</ul></body></html>
";

        public override string FormatLines(IEnumerable<string> lines)
        {
            var outputBuilder = new StringBuilder();
            outputBuilder.Append(_header);

            var regex = new Regex(@"\e\[(3[0-7]|90|1)m(.*)");
            foreach(var line in lines.Select(x => { var r = new Regex(@"\e\[0m"); return r.Replace(x, ""); }))
            {
                var match = regex.Match(line);
                if(match.Success) {
                    var styledLine = $"<span class=\"{_styles[match.Groups[1].Value]}\">{match.Groups[2].Value}</span>";
                    outputBuilder.AppendLine(styledLine);
                }
                else
                {
                    outputBuilder.AppendLine(line);
                }
            }

            outputBuilder.Append(_footer);

            return outputBuilder.ToString();
        }
    }
}