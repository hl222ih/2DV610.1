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

        public HalfCircle(int cx, int cy, int radius, ShapeType shapeType) : base(shapeType)
        {
            CX = cx;
            CY = cy;
            Radius = radius;
        }

        public override bool HorizontallyTranslates(Shape shape)
        {
            if (ShapeType != shape.ShapeType) return false;

            return Y == shape.Y && Radius == ((HalfCircle)shape).Radius;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            HalfCircle h = (HalfCircle)obj;

            return X == h.X && Y == h.Y && Radius == h.Radius;
        }

        public override string GetPath()
        {
            throw new NotImplementedException();
        }
    }
}
