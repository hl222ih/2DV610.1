using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class Line : Shape
    {
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }
        public double Length
        {
            get
            {
                return Math.Sqrt(Width * Width + Height * Height); //may overflow
            }
        }

        /// <summary>
        /// Instantiates a Circle object.
        /// </summary>
        /// <param name="x1">x coordinate of the beginning of the line</param>
        /// <param name="y1">y coordinate of the beginning of the line</param>
        /// <param name="x2">x coordinate of the end of the line</param>
        /// <param name="y2">y coordinate of the end of the line</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when line will not fit a box (0,0) to (intmax, 1280).</exception>
        /// <remarks>(x1,y1) might switch place with (x2,y2) so that X1 will be the leftmost x coordinate and in case the line is vertical Y1 will be the uppermost y coordinate.</remarks>
        public Line(int x1, int y1, int x2, int y2) : base(ShapeType.Line)
        {
            if (x1 < x2)
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
            }
            else if (x1 > x2)
            {
                X1 = x2;
                Y1 = y2;
                X2 = x1;
                Y2 = y1;
            }
            else
            {
                X1 = x1;
                X2 = x2;
                if (y1 <= y2)
                {
                    Y1 = y1;
                    Y2 = y2;
                }
                else
                {
                    Y1 = y2;
                    Y2 = y1;
                }
            }
                
            X = X1;
            Y = Y1;
            Width = X2 - X1;
            Height = Math.Abs(Y2 - Y1);
        }
    }
}
