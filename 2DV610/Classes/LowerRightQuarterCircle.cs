﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class LowerRightQuarterCircle : QuarterCircle
    {
        public LowerRightQuarterCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.LowerRightQuarterCircle)
        {
            X = cx;
            Y = cy;
            Height = radius;
            Width = radius;
        }
    }
}
