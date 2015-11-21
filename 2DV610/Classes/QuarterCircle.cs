using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class QuarterCircle : Shape
    {
        public int CX { get; protected set; }
        public int CY { get; protected set; }
        public int Radius { get; protected set; }

        public QuarterCircle(int cx, int cy, int radius, ShapeType shapeType) : base(shapeType)
        {
            if (radius < 0) throw new ArgumentOutOfRangeException("Radius not allowed to be negative.");

            CX = cx;
            CY = cy;
            Radius = radius;
        }

        public override bool HorizontallyTranslates(Shape shape)
        {
            throw new NotImplementedException();
        }

        public override string GetPath()
        {
            throw new NotImplementedException();
        }
    }
}
