using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class UpperHalfCircle : HalfCircle
    {
        public UpperHalfCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.UpperHalfCircle)
        {
            X = cx - radius;
            Y = cy - radius;
            Width = radius * 2;
            Height = radius;
        }
    }
}
