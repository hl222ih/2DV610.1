using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class RightQuarterCircle : QuarterCircle
    {
        public new float Width { get; protected set; }

        public RightQuarterCircle(int cx, int cy, float radius) : base(cx, cy, (int)Math.Round(radius / Math.Sqrt(2) * 1.5, 0), ShapeType.RightQuarterCircle)
        {
            Height = (int)Math.Round(radius / Math.Sqrt(2) * 2, 0);
            base.Width = Height / 4;
            Width = radius - Height / 2;
            X = cx;
            Y = cy - Height / 2;
        }
    }
}
