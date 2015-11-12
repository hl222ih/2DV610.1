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
        private const int BoxWidth = 128000; //More than enough. Normally we are working with widhts of 1000-5000.

        private int x;
        private int y;
        private int width;
        private int height;


        public ShapeType ShapeType { get; private set; }

        /// <summary>
        /// Upper left x coordinate of circumscribed rectangle of the shape.
        /// </summary>
        public int X
        {
            get { return x; }
            protected set
            {
                if (value < 0 || value > BoxWidth - Width)
                    throw new ArgumentOutOfRangeException("Shape outside box (0,0),(128000,1280)");
                x = value;
            }
        }

        /// <summary>
        /// Upper left y coordinate of circumscribed rectangle of the shape.
        /// </summary>
        public int Y
        {
            get { return y; }
            protected set
            {
                if (value < 0 || value > BoxHeight - Height)
                    throw new ArgumentOutOfRangeException("Shape outside box (0,0),(128000,1280)");
                y = value;
            }
        }

        public int Width
        {
            get { return width; }
            protected set
            {
                if (value < 0 || value > BoxWidth - x)
                    throw new ArgumentOutOfRangeException("Shape outside box (0,0),(128000,1280)");
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            protected set
            {
                if (value < 0 || value > BoxHeight - y)
                    throw new ArgumentOutOfRangeException("Shape outside box (0,0),(128000,1280)");
                height = value;
            }
        }

        public Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }

        public abstract bool HorizontallyTranslates(Shape shape);

        public abstract string GetPath();
    }
}
