﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class UpperLeftQuarterCircle : QuarterCircle
    {
        public UpperLeftQuarterCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.UpperLeftQuarterCircle)
        {
            X = cx - radius;
            Y = cy - radius;
            Height = radius;
            Width = radius;
        }
    }
}
