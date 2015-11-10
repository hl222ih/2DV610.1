using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class Circle : Shape
    {
        public int CX { get; private set; }
        public int CY { get; private set; }
        public int Radius { get; private set; }

        public Circle(int cx, int cy, int radius) : base(ShapeType.Circle)
        {
            CX = cx;
            CY = cy;
            Radius = radius;
        }        
    }
}
