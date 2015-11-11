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
        public double Length { get; }

        public Line(int x1, int y1, int x2, int y2) : base(ShapeType.Line)
        {
        }
    }
}
