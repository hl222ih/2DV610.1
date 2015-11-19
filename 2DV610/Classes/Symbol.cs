﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2DV610.Classes
{
    public class Symbol
    {
        protected List<Symbol> symbols;
        protected List<Shape> shapes;
        protected List<PathCommand> pathCommands; //extracted from path, used to create shapes

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

        public Symbol(string svgPath)
        {
            Initialize();

            string[] paths = SplitPath(svgPath);
            CreatePathCommands(paths);

            CreateShapes();

        }

        private void Initialize()
        {
            pathCommands = new List<PathCommand>();
            symbols = new List<Symbol>();
            shapes = new List<Shape>();
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


        protected void CreatePathCommands(string[] paths)
        {
            float startX = 0;
            float startY = 0;
            for (int i = 0; i < paths.Length; i++)
            {
                PathCommand command = new PathCommand(paths[i], startX, startY);
                startX = command.EndX;
                startY = command.EndY;
                pathCommands.Add(command);
            }
        }

        /// <summary>
        /// Splits the SVG path data to a string array with one path command in each string.
        /// </summary>
        /// <param name="path">The path data with one or more path commands.</param>
        /// <returns>The splitted path.</returns>
        protected string[] SplitPath(string path)
        {
            MatchCollection matchList = Regex.Matches(path, @"([MmZzLlHhVvCcSsQqTtAa][^MmZzLlHhVvCcSsQqTtAa]*)");
            string[] paths = matchList.Cast<Match>().Select(match => match.Value).ToArray();

            return paths;
        }

        protected void CreateShapes()
        {
            for (int i = 0; i < pathCommands.Count; i++)
            {
                PathCommand c = pathCommands[i];

                Shape shape = CreateShape(c);
                if (shape != null)
                {
                    shapes.Add(shape);
                }

            }

        }

        protected Shape CreateShape(PathCommand c)
        {
            Shape shape = null;
            if (c.IsMoveToCommand())
            {
                //
            }
            else if (c.IsArcCommand())
            {
                if (c.IsCircular())
                {
                    if (c.IsHorizontal())
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
                    else
                    if (c.IsVertical())
                    {
                        if (c.IsLeft())
                        {
                            shape = new LeftHalfCircle((int)c.CenterX, (int)c.CenterY, (int)c.RadiusY);
                        }
                        else if (c.IsRight())
                        {
                            shape = new RightHalfCircle((int)c.CenterX, (int)c.CenterY, (int)c.RadiusY);
                        }
                    }
                }
            }
            return shape;
        }
    }
}
