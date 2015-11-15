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
        private List<Symbol> symbols;
        private List<Shape> shapes;
        private string[] pathElements;
        private List<PathCommand> pathCommands; //extracted from path, used to create shapes

        public PathCommand[] PathCommands
        {
            get
            {
                return pathCommands.ToArray();
            }
        }

        public int CommandCount
        {
            get
            {
                return pathCommands.Count;
            }
        }

        public Symbol(PathCommand[] commands)
        {
            symbols = new List<Symbol>();
            shapes = new List<Shape>();

            for (int i = 0; i < commands.Length; i++)
            {
                PathCommand c = commands[i];
                
                if (c.IsMoveToCommand())
                {
                    //
                }
                else if (commands[i].IsArcCommand())
                {
                    Shape shape = null;
                    if (c.RadiusX == c.RadiusY && c.StartY == c.EndY) //IsCircular, IsHorizontal
                    {
                        if (c.IsLower())
                        {
                            shape = new LowerHalfCircle((int)c.CenterX, (int)c.CenterY, (int)c.RadiusX);
                        }
                        else if (c.IsUpper())
                        {
                            shape = new UpperHalfCircle((int)c.CenterX, (int)c.CenterY, (int)c.RadiusX);
                        }
                    }

                    if (shape != null)
                    {
                        shapes.Add(shape);
                    }
                }
            }
        }
        public Symbol(string svgPath)
        {
            Initialize(svgPath);

            for (int i = 0; i < pathCommands.Count; i++)
            {
                PathCommand c = pathCommands[i];

                if (c.IsMoveToCommand())
                {
                    //
                }
                else if (pathCommands[i].IsArcCommand())
                {
                    Shape shape = null;
                    if (c.RadiusX == c.RadiusY && c.StartY == c.EndY) //IsCircular, IsHorizontal
                    {
                        if (c.IsLower())
                        {
                            shape = new LowerHalfCircle((int)c.CenterX, (int)c.CenterY, (int)c.RadiusX);
                        }
                        else if (c.IsUpper())
                        {
                            shape = new UpperHalfCircle((int)c.CenterX, (int)c.CenterY, (int)c.RadiusX);
                        }
                    }

                    if (shape != null)
                    {
                        shapes.Add(shape);
                    }
                }
            }
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

        private void Initialize(string svgPath)
        {
            pathCommands = new List<PathCommand>();
            string[] paths = SplitMultiCommandSvgPath(svgPath);
            float startX = 0;
            float startY = 0;
            for (int i = 0; i < paths.Length; i++)
            {
                PathCommand command = new PathCommand(paths[i], startX, startY);
                startX = command.EndX;
                startY = command.EndY;
                pathCommands.Add(command);
            }

            symbols = new List<Symbol>();
            shapes = new List<Shape>();

            MatchCollection matchList = Regex.Matches(svgPath, @"(\d+|[MAa]|,)");
            pathElements = matchList.Cast<Match>().Select(match => match.Value).ToArray();

        }
        private string[] SplitMultiCommandSvgPath(string path)
        {
            MatchCollection matchList = Regex.Matches(path, @"([MmZzLlHhVvCcSsQqTtAa][^MmZzLlHhVvCcSsQqTtAa]*)");
            string[] paths = matchList.Cast<Match>().Select(match => match.Value).ToArray();

            return paths;
        }

    }
}
