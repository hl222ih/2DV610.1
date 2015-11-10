using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class Shape
    {
        public ShapeType PathType { get; private set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Shape(ShapeType pathType)
        {
            PathType = pathType;
        }
    }
}
