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
                case "A":
                    relativeElements[6] = (float.Parse(elems[6]) - currentX).ToString();
                    relativeElements[7] = (float.Parse(elems[7]) - currentY).ToString();
                    absoluteElements[6] = elems[6];
                    absoluteElements[7] = elems[7];
                    break;
                case "a":
                    absoluteElements[6] = (float.Parse(elems[6]) + currentX).ToString();
                    absoluteElements[7] = (float.Parse(elems[7]) + currentY).ToString();
                    relativeElements[6] = elems[6];
                    relativeElements[7] = elems[7];
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
            else if (relativeElements[0] == "a")
            {
                path = GetRelativeArcPath(relativeElements[1], relativeElements[2], relativeElements[3], relativeElements[4], relativeElements[5], relativeElements[6], relativeElements[7]);
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
            else if (absoluteElements[0] == "A")
            {
                path = GetAbsoluteArcPath(absoluteElements[1], absoluteElements[2], absoluteElements[3], absoluteElements[4], absoluteElements[5], absoluteElements[6], absoluteElements[7]);
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

        private string GetRelativeArcPath(string rx, string ry, string xAxisRotation, string largeArcFlag, string sweepFlag, string x, string y)
        {
            return String.Format("a{0},{1} {2} {3},{4} {5},{6}", rx, ry, xAxisRotation, largeArcFlag, sweepFlag, x, y);
        }

        private string GetAbsoluteArcPath(string rx, string ry, string xAxisRotation, string largeArcFlag, string sweepFlag, string x, string y)
        {
            return String.Format("A{0},{1} {2} {3},{4} {5},{6}", rx, ry, xAxisRotation, largeArcFlag, sweepFlag, x, y);
        }

    }
}
