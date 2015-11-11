using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class Shape
    {
        private const int BoxHeight = 1280;
        private const int BoxWidth = int.MaxValue;

        private int x;
        private int y;
        private int width;
        private int height;


        public ShapeType ShapeType { get; private set; }

        public int X
        {
            get { return x; }
            protected set
            {
                if (value < 0 || value > BoxWidth - Width)
                    throw new ArgumentOutOfRangeException();
                x = value;
            }
        }

        public int Y
        {
            get { return y; }
            protected set
            {
                if (value < 0 || value > BoxHeight - Height)
                    throw new ArgumentOutOfRangeException();
                y = value;
            }
        }

        public int Width
        {
            get { return width; }
            protected set
            {
                if (value < 0 || value > BoxWidth - x)
                    throw new ArgumentOutOfRangeException();
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            protected set
            {
                if (value < 0 || value > BoxHeight - y)
                    throw new ArgumentOutOfRangeException();
                height = value;
            }
        }

        public Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }
    }
}
