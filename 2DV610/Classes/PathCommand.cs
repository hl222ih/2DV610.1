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
            
            relativeElements = elems;
            absoluteElements = elems;
        }

        public string GetRelativePath()
        {
            return relativeElements.ToString();
        }

    }
}
