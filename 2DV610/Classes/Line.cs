using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class Line : Shape
    {
        int startX;
        int startY;
        int endX;
        int endY;

        /// <summary>
        /// Creates a Line path.
        /// </summary>
        /// <param name="path">"L startX startY diffX diffY"</param>
        public Line(String path) : base(ShapeType.Line)
        {
            string[] pathArr = path.Split(' ');
            if (pathArr.Length != 5) throw new ArgumentException("Not correct number of arguments in string.");
            if (!pathArr[0].Equals("L")) throw new ArgumentException("Not correct path type given in first string argument.");

            int diffX;
            int diffY;

            try
            {
                string s = pathArr[0];
                startX = int.Parse(pathArr[1]);
                startY = int.Parse(pathArr[2]);
                diffX = int.Parse(pathArr[3]);
                diffY = int.Parse(pathArr[4]);
            }
            catch
            {
                throw new ArgumentException("X and Y values must be integers");
            }

            if (diffX == 0 && diffY == 0)
            {
                throw new ArgumentException("Line may not be of zero length");
            }
        }
    }
}
