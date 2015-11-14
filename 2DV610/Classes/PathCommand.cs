using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2DV610.Classes
{
    public class PathCommand
    {
        string[] relativeElements;
        string[] absoluteElements;

        public PathCommand(string svgCommandPath, float currentX = 0, float currentY = 0)
        {
            //match path elements that are valid path commands and floats
            MatchCollection matchList = Regex.Matches(svgCommandPath, @"([MmZzLlHhVvCcSsQqTtAa]|\d+(?:\.\d+)?)");
            //put the matched elements in an Array
            string[] elems = matchList.Cast<Match>().Select(match => match.Value).ToArray();

            relativeElements = (string[])elems.Clone();
            absoluteElements = (string[])elems.Clone();

            switch (elems[0])
            {
                case "M":
                    relativeElements[0] = "m";
                    absoluteElements[0] = "M";
                    relativeElements[1] = (float.Parse(elems[1]) - currentX).ToString();
                    absoluteElements[1] = elems[1];
                    relativeElements[2] = (float.Parse(elems[2]) - currentY).ToString();
                    absoluteElements[2] = elems[2];
                    break;
                default:
                    break;
            }

        }

        public string GetRelativePath()
        {
            string path = String.Empty;

            if (relativeElements[0] == "m")
            {
                path = GetRelativeMoveToPath(relativeElements[1], relativeElements[2]);
            }

            return path;
        }

        private string GetRelativeMoveToPath(string x, string y)
        {
            return String.Format("m{0},{1}", x, y);
        }

    }
}
