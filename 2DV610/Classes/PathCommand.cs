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

            relativeElements[0] = elems[0].ToLower();
            absoluteElements[0] = elems[0].ToUpper();

            switch (elems[0])
            {
                case "M":
                    relativeElements[1] = (float.Parse(elems[1]) - currentX).ToString();
                    relativeElements[2] = (float.Parse(elems[2]) - currentY).ToString();
                    absoluteElements[1] = elems[1];
                    absoluteElements[2] = elems[2];
                    break;
                case "m":
                    relativeElements[1] = elems[1];
                    relativeElements[2] = elems[2];
                    absoluteElements[1] = (float.Parse(elems[1]) + currentX).ToString();
                    absoluteElements[2] = (float.Parse(elems[2]) + currentY).ToString();
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

        public string GetAbsolutePath()
        {
            string path = String.Empty;

            if (absoluteElements[0] == "M")
            {
                path = GetAbsoluteMoveToPath(absoluteElements[1], absoluteElements[2]);
            }

            return path;
        }

        private string GetRelativeMoveToPath(string x, string y)
        {
            return String.Format("m{0},{1}", x, y);
        }

        private string GetAbsoluteMoveToPath(string x, string y)
        {
            return String.Format("M{0},{1}", x, y);
        }
    }
}
