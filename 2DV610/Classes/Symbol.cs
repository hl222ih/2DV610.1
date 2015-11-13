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
            
            MatchCollection matchList = Regex.Matches(svgPath, @"(\d+|[MAa]|,)");
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
                    //TODO: check that pathElements have enough elements for M.
                    int x = 0;
                    int y = 0;
                    if (int.TryParse(pathElements[i + 1], out x) &&
                        pathElements[i + 2] == "," &&
                        int.TryParse(pathElements[i + 3], out y))
                    {
                        currentX = x;
                        currentY = y;

                        i += 3;
                    }
                    //else
                    //{
                    //throw new FormatException("Couldn't parse passed in string");
                    //}
                }
                else if (pathElements[i].Equals("A", StringComparison.OrdinalIgnoreCase))
                {
                    //TODO: check that pathElements have enough elements for A/a.
                    int rx = 0;
                    int ry = 0;
                    int x = 0;
                    int y = 0;
                    double disregard;

                    if (int.TryParse(pathElements[i + 1], out rx) &&
                        pathElements[i + 2] == "," &&
                        int.TryParse(pathElements[i + 3], out ry) &&
                        double.TryParse(pathElements[i + 4], out disregard) &&
                        (pathElements[i + 5] == "0" || pathElements[i + 5] == "1") &&
                        pathElements[i + 6] == "," &&
                        (pathElements[i + 7] == "0" || pathElements[i + 7] == "1") &&
                        int.TryParse(pathElements[i + 8], out x) &&
                        pathElements[i + 9] == "," &&
                        int.TryParse(pathElements[i + 10], out y))
                    {


                        Shape shape;
                        if (pathElements[i + 7] == "0") //sweep-flag is 0
                        {
                            if (currentX < x) //left-to-right
                            {
                                shape = new LowerHalfCircle(currentX + rx, currentY, rx);
                            }
                            else //right-to-left
                            {
                                shape = new UpperHalfCircle(currentX - rx, currentY, rx);
                            }
                        }
                        else //sweep-flag is 1
                        {
                            if (currentX > x) //right-to-left
                            {
                                shape = new LowerHalfCircle(currentX - rx, currentY, rx);
                            }
                            else //left-to-right
                            {
                                shape = new UpperHalfCircle(currentX + rx, currentY, rx);
                            }
                        }

                        shapes.Add(shape);

                        //adjust current coordinates
                        if (pathElements[i] == "a") //relative
                        {
                            currentX += x;
                            currentY += y;
                        }
                        else //"A", absolute
                        {
                            currentX = x;
                            currentY = y;
                        }

                        i += 10;
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

        public bool Contains(Shape shape)
        {
            return shapes.Exists(s => s.HorizontallyTranslates(shape));
        }
    }
}
