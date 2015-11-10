using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class Shape
    {
        private ShapeType pathType;
        
        public Shape(ShapeType pathType)
        {
            this.pathType = pathType;
        }

        public ShapeType GetPathType()
        {
            return pathType;
        }
    }
}
