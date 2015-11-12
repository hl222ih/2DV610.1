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

        public Ear(int x, int y, ShapeType shapeType) : base(shapeType)
        {
            X = x;
            Y = y;

            //Ear shapes has a fixed width and height
            Width = 256;
            Height = 512;

            TopY = y;
            MidY = y + Height / 4;
            BottomY = y + Height;
            LeftX = x;
            RightX = x + Width;
        }
    }
}
