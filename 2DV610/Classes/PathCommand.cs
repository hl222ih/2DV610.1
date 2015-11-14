﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class PathCommand
    {
        string[] relativeElements;
        string[] absoluteElements;

        public PathCommand(string[] elements, float currentX = 0, float currentY = 0)
        {
            relativeElements = elements;
            absoluteElements = elements;
        }
    }
}
