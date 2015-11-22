using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class UpperRightQuarterCircle : QuarterCircle
    {
        public UpperRightQuarterCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.UpperRightQuarterCircle)
        {
            X = cx;
            Y = cy - radius;
            Height = radius;
            Width = radius;
        }
    }
}
