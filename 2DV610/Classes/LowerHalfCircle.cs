﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class LowerHalfCircle : HalfCircle
    {
        public LowerHalfCircle(int cx, int cy, int radius) : base(cx, cy, radius, ShapeType.LowerHalfCircle)
        {
            X = cx - radius;
            Y = cy;
            Width = radius * 2;
            Height = radius;
        }
    }
}
