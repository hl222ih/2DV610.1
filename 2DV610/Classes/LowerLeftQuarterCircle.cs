using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class LowerLeftQuarterCircle : QuarterCircle
    {
        public LowerLeftQuarterCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.LowerLeftQuarterCircle)
        {
            X = cx - radius;
            Y = cy;
            Height = radius;
            Width = radius;
        }
    }
}
