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
        public int Diameter
        {
            get
            {
                return Radius * 2;
            }
        }

        /// <summary>
        /// Instantiates a Circle object.
        /// </summary>
        /// <param name="cx">the x coordinate of circle's center</param>
        /// <param name="cy">the y coordinate of circle's center</param>
        /// <param name="radius">the circle's radius</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when circle will not fit a box (0,0) to (intmax, 1280).</exception>
        public Circle(int cx, int cy, int radius) : base(ShapeType.Circle)
        {
            CX = cx;
            CY = cy;
            Radius = radius;
            X = cx - radius;
            Y = cy - radius;
            Width = radius * 2;
            Height = radius * 2;
        }

        public Circle(int x, int y, int diameter, bool dummy) : base(ShapeType.Circle)
        {
            CX = x + diameter / 2;
            CY = y + diameter / 2;
            Radius = diameter / 2;
            X = x;
            Y = y;
            Width = diameter;
            Height = diameter;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            Circle c = (Circle)obj;
            return X == c.X && Y == c.Y && Radius == c.Radius;
        }

        public override int GetHashCode()
        {
            return X * Y * Radius; //possible overflow ok
        }

        public override bool HorizontallyTranslates(Shape shape)
        {
            throw new NotImplementedException();
        }
    }
}
