using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2DV610.Classes
{
    public class Symbol
    {
        List<Symbol> symbols;
        List<Shape> shapes;

        string[] pathElements;

        public Symbol(string svgPath)
        {
            symbols = new List<Symbol>();
            shapes = new List<Shape>();
            
            MatchCollection matchList = Regex.Matches(svgPath, @"(\d+|[MA]|,)");
            pathElements = matchList.Cast<Match>().Select(match => match.Value).ToArray();

            int currentX = 0;
            int currentY = 0;

            //Mx,y mx,y
            //Lx,y lx,y
            //Vx,y vx,y
            //Hx,y hx,y
            //Arx,ry 0 1,0 endX,endY
            for (int i = 0; i < pathElements.Length; i++)
            {
                if (pathElements[i] == "M")
                {
                    int x = 0;
                    int y = 0;
                    if (int.TryParse(pathElements[i + 1], out x) &&
                        pathElements[i + 2] == "," &&
                        int.TryParse(pathElements[i + 3], out y))
                    {
                        i += 3;
                        currentX = x;
                        currentY = y;

                    }
                    //else
                    //{
                    //throw new FormatException("Couldn't parse passed in string");
                    //}
                }
                else if (pathElements[i] == "A")
                {
                    int rx = 0;
                    int ry = 0;
                    int x = 0;
                    int y = 0;

                    if (int.TryParse(pathElements[i + 1], out rx) &&
                        pathElements[i + 2] == "," &&
                        int.TryParse(pathElements[i + 3], out ry) &&
                        pathElements[i + 4] == "0" &&
                        pathElements[i + 5] == "1" &&
                        pathElements[i + 6] == "," &&
                        pathElements[i + 7] == "0" &&
                        int.TryParse(pathElements[i + 8], out x) &&
                        pathElements[i + 9] == "," &&
                        int.TryParse(pathElements[i + 10], out y))
                    {
                        i += 10;
                        currentX = x;
                        currentY = y;
                        Shape shape = new LowerHalfCircle(currentX, currentY, rx);
                        shapes.Add(shape);
                    }
                    //else
                    //{
                    //throw new FormatException("Couldn't parse passed in string");
                    //}
                }
                //else
                //{
                //throw new FormatException("Couldn't parse passed in string");
                //}
            }

            //foreach (Symbol symbol in symbols)
            //{
            //throw new NotImplementedException();
            //}
        }

        public Symbol(string[] svgPaths)
        {
            throw new NotImplementedException();
        }

        public void AddShape(Shape shape)
        {
            throw new NotImplementedException();
        }

        public List<Shape> GetShapes()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ShapeType shapeType)
        {
            return shapes.Exists(s => s.ShapeType == shapeType);
        }
    }
}
