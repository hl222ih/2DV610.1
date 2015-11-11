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
    }
}
