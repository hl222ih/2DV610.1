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

        public Line(int x1, int y1, int x2, int y2) : base(ShapeType.Line)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X = x1;
            Y = y1;
            Width = x2 - x1;
            Height = y2 - y1;            
        }
    }
}
