using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class UpperQuarterCircle : QuarterCircle
    {
        public new float Height { get; protected set; }
        public new float Y { get; protected set; }

        public UpperQuarterCircle(int cx, int cy, float radius) : base(cx, cy, (int)Math.Round(radius / Math.Sqrt(2) * 1.5, 0), ShapeType.UpperQuarterCircle)
        {
            Width = (int)Math.Round(radius / Math.Sqrt(2) * 2, 0);
            base.Height = Width / 4;
            Height = radius - Width / 2;
            X = cx - Width / 2;
            base.Y = cy - base.Height;
            Y = cy - radius;
        }
    }
}
