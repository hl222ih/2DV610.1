using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class LeftQuarterCircle : QuarterCircle
    {
        public new float X { get; protected set; }
        public new float Width { get; protected set; }

        public LeftQuarterCircle(int cx, int cy, float radius) : base(cx, cy, (int)Math.Round(radius / Math.Sqrt(2) * 1.5, 0), ShapeType.LeftQuarterCircle)
        {
            Height = (int)Math.Round(radius / Math.Sqrt(2) * 2, 0);
            base.Width = Height / 4;
            Width = radius - Height / 2;
            Y = cy - Height / 2;
            base.X = cx - base.Width;
            X = cx - radius;
        }
    }
}
