using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class HalfCircle : Shape
    {
        public HalfCircle() : base(ShapeType.HalfCircle)
        {
        }

        public override bool HorizontallyTranslates(Shape shape)
        {
            throw new NotImplementedException();
        }

        public override string GetPath()
        {
            throw new NotImplementedException();
        }
    }
}
