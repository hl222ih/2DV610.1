using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class LeftEar : Ear
    {
        public LeftEar(int x, int y) : base(ShapeType.LeftEar)
        {
            X = x;
            Y = y;
            //Ear shapes has a fixed width and height
            Width = 256;
            Height = 512;

            TopY = Y;
            MidY = Y + Height / 4;
            BottomY = Y + Height;
            LeftX = X;
            RightX = X + Width;
        }
    }
}
