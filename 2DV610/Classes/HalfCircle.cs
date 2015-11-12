using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class HalfCircle : Shape
    {
        public int CX { get; protected set; }
        public int CY { get; protected set; }
        public int Radius { get; protected set; }

        public HalfCircle(int x, int y, int radius, ShapeType shapeType) : base(shapeType)
        {
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
