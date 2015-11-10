using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class Svg
    {
        public Symbol Symbol { get; private set; }

        public Svg(string path)
        {
            Symbol = new Symbol();
        }
    }
}
