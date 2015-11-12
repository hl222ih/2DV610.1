using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class Ear : Shape
    {
        public int TopY { get; protected set; }
        public int MidY { get; protected set; }
        public int BottomY { get; protected set; }
        public int LeftX { get; protected set; }
        public int RightX { get; protected set; }

        public Ear(ShapeType shapeType) : base(shapeType)
        {
        }
    }
}
