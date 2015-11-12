using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class LeftHalfCircle : HalfCircle
    {
        public LeftHalfCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.LeftHalfCircle)
        {
            X = cx - radius;
            Y = cy - radius;
            Width = radius;
            Height = radius * 2;
        }
    }
}
