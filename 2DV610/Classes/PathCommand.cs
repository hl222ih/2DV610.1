using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2DV610.Classes
{
    public class PathCommand
    {
        public enum CType
        {
            Undefined,
            MoveTo, //M
            ClosePath, //Z
            LineTo, //L
            HorizontalLineTo, //H
            VerticalLineTo, //V
            CurveTo, //C (cubic)
            ShorthandCurveTo, //S (cubic)
            QuadraticCurveTo, //Q
            ShorthandQuadraticCurveTo, //T
            EllipticalArc //A

        }

        public CType CommandType { get; set; }

        private string[] relativeElements;
        private string[] absoluteElements;

        /// <summary>
        /// Gets the x coordinate of the point the path command is originating from.
        /// </summary>
        public float StartX { get; private set; }

        /// <summary>
        /// Gets the y coordinate of the point the path command is originating from.
        /// </summary>
        public float StartY { get; private set; }

        /// <summary>
        /// Gets the x coordinate of the point the path command is finishing in.
        /// </summary>
        public float EndX { get; private set; }

        /// <summary>
        /// Gets the y coordinate of the point the path command is finishing in.
        /// </summary>
        public float EndY { get; private set; }

        /// <summary>
        /// Gets the x coordinate of the middle point between the start and end point.
        /// For M command: Same as EndX.
        /// For A command: the x coordinate of the fully drawn circle/ellipse's center point.
        /// </summary>
        public float CenterX
        {
            get
            {
                float cx = 0;

                switch (CommandType)
                {
                    case CType.MoveTo:
                        cx = EndX;
                        break;
                    case CType.EllipticalArc:
                        cx = (StartX + EndX) / 2;
                        if (EndX - StartX == RadiusX)
                        {
                            if (relativeElements[5] == "1")
                            {
                                cx = StartX;
                            }
                            else if (relativeElements[5] == "0")
                            {
                                cx = EndX;
                            }
                        }
                        else if (StartX - EndX == RadiusX)
                        {
                            if (relativeElements[5] == "1")
                            {
                                cx = EndX;
                            }
                        }
                        break;
                    default:
                    break;
                }

                return cx;
            }
        }

        /// <summary>
        /// Gets the y coordinate of the middle point between the start and end point.
        /// For M command: Same as EndY.
        /// For A command: the y coordinate of the fully drawn circle/ellipse's center point.
        /// </summary>
        public float CenterY
        {
            get
            {
                float cy = 0;

                switch (CommandType)
                {
                    case CType.MoveTo:
                        cy = EndY;
                        break;
                    case CType.EllipticalArc:
                        cy = (StartY + EndY) / 2;
                        if (EndY - StartY == RadiusY)
                        {
                            if (EndX - StartX == RadiusX)
                            {
                                if (relativeElements[5] == "1")
                                {
                                    cy = EndY;
                                }
                                else if (relativeElements[5] == "0")
                                {
                                    cy = EndY;
                                }
                            }
                            else if (StartX - EndX == RadiusX)
                            {
                                if (relativeElements[5] == "1")
                                {
                                    cy = StartY;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }

                return cy;
            }
        }

        /// <summary>
        /// Gets the value 0.
        /// For A command: The distance between a point on the left/right boundary to the center point of a non tilted circle/ellipse.
        /// The x radius value does not change if the circle/ellipse is tilted.
        /// </summary>
        public float RadiusX
        {
            get
            {
                float rx = 0;

                switch (CommandType)
                {
                    case CType.EllipticalArc:
                        float.TryParse(relativeElements[1], out rx);
                        break;
                    default:
                        break;
                }

                return rx;
            }
        }

        /// <summary>
        /// Gets the value 0.
        /// For A command: The distance between a point on the upper/lower boundary to the center point of a non tilted circle/ellipse.
        ///                The y radius value does not change if the circle/ellipse is tilted.
        /// </summary>
        public float RadiusY
        {
            get
            {
                float ry = 0;

                switch (CommandType)
                {
                    case CType.EllipticalArc:
                        float.TryParse(relativeElements[2], out ry);
                        break;
                    default:
                        break;
                }

                return ry;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathCommand"/> class.
        /// Only pass a single command.
        /// If M18,64a32,32 0 0,1 64,0a32,32 0 0,1 -64,0 is the full path, pass
        /// "M18,64" first time and
        /// "a32,32 0 0,1 64,0", 18, 64 next time.
        /// Supports only a small subset of correct path data syntax and will throw an exception if string is not entirely parsable.
        /// </summary>
        /// <param name="svgCommandPath">The SVG command path.</param>
        /// <param name="startX">The current x coordinate (default 0).</param>
        /// <param name="startY">The current y coordinate (default 0).</param>
        public PathCommand(string svgCommandPath, float startX = 0, float startY = 0)
        {
            StartX = startX;
            StartY = startY;
            string[] elems = ParsePathElements(svgCommandPath);
            AdjustElementsValues(elems);
        }

        /// <summary>
        /// Parses the command path into path elements: absolute and relative commands MmZzLlHhVvCcSsQqTtAa and float values.
        /// </summary>
        /// <param name="svgCommandPath">The SVG path.</param>
        /// <returns>String array of the parsed svgCommandPath</returns>
        private string[] ParsePathElements(string svgCommandPath)
        {
            MatchCollection matchList = Regex.Matches(svgCommandPath, @"([MmZzLlHhVvCcSsQqTtAa]|\-?\d+(?:\.\d+)?)");
            string[] elems = matchList.Cast<Match>().Select(match => match.Value).ToArray();

            return elems;
        }

        /// <summary>
        /// Adjusts the elements values, so that no matter if the original path was given with absolute or relative values,
        /// there will be an array of relative commands and relative values as well as an array of absolute commands and absolute values;
        /// </summary>
        /// <param name="elems">The elements from a svg command path.</param>
        private void AdjustElementsValues(string[] elems)
        {
            relativeElements = (string[])elems.Clone();
            absoluteElements = (string[])elems.Clone();

            relativeElements[0] = elems[0].ToLower();
            absoluteElements[0] = elems[0].ToUpper();
            
            switch (elems[0])
            {
                case "M":
                    CommandType = CType.MoveTo;
                    EndX = float.Parse(elems[1]);
                    EndY = float.Parse(elems[2]);
                    relativeElements[1] = (EndX - StartX).ToString();
                    relativeElements[2] = (EndY - StartY).ToString();
                    break;
                case "m":
                    CommandType = CType.MoveTo;
                    EndX = float.Parse(elems[1]) + StartX;
                    EndY = float.Parse(elems[2]) + StartY;
                    absoluteElements[1] = EndX.ToString();
                    absoluteElements[2] = EndY.ToString();
                    break;
                case "A":
                    CommandType = CType.EllipticalArc;
                    EndX = float.Parse(elems[6]);
                    EndY = float.Parse(elems[7]);
                    relativeElements[6] = (EndX - StartX).ToString();
                    relativeElements[7] = (EndY - StartY).ToString();
                    break;
                case "a":
                    CommandType = CType.EllipticalArc;
                    EndX = float.Parse(elems[6]) + StartX;
                    EndY = float.Parse(elems[7]) + StartY;
                    absoluteElements[6] = EndX.ToString();
                    absoluteElements[7] = EndY.ToString();
                    break;
                default:
                    CommandType = CType.Undefined;
                    break;
            }

        }

        /// <summary>
        /// Gets the relative command path.
        /// </summary>
        /// <returns>The command path with relative commands and values.</returns>
        public string GetRelativePath()
        {
            string path = String.Empty;

            if (relativeElements[0] == "m")
            {
                path = GetRelativeMoveToPath(relativeElements[1], relativeElements[2]);
            }
            else if (relativeElements[0] == "a")
            {
                path = GetRelativeArcPath(relativeElements[1], relativeElements[2], relativeElements[3], relativeElements[4], relativeElements[5], relativeElements[6], relativeElements[7]);
            }

            return path;
        }

        /// <summary>
        /// Gets the absolute command path.
        /// </summary>
        /// <returns>The command path with absolute commands and values.</returns>
        public string GetAbsolutePath()
        {
            string path = String.Empty;

            if (absoluteElements[0] == "M")
            {
                path = GetAbsoluteMoveToPath(absoluteElements[1], absoluteElements[2]);
            }
            else if (absoluteElements[0] == "A")
            {
                path = GetAbsoluteArcPath(absoluteElements[1], absoluteElements[2], absoluteElements[3], absoluteElements[4], absoluteElements[5], absoluteElements[6], absoluteElements[7]);
            }

            return path;
        }

        private string GetRelativeMoveToPath(string x, string y)
        {
            return String.Format("m{0},{1}", x, y);
        }

        private string GetAbsoluteMoveToPath(string x, string y)
        {
            return String.Format("M{0},{1}", x, y);
        }

        private string GetRelativeArcPath(string rx, string ry, string xAxisRotation, string largeArcFlag, string sweepFlag, string x, string y)
        {
            return String.Format("a{0},{1} {2} {3},{4} {5},{6}", rx, ry, xAxisRotation, largeArcFlag, sweepFlag, x, y);
        }

        private string GetAbsoluteArcPath(string rx, string ry, string xAxisRotation, string largeArcFlag, string sweepFlag, string x, string y)
        {
            return String.Format("A{0},{1} {2} {3},{4} {5},{6}", rx, ry, xAxisRotation, largeArcFlag, sweepFlag, x, y);
        }

        public bool IsMoveToCommand()
        {
            return (CommandType == CType.MoveTo);
        }

        public bool IsArcCommand()
        {
            return (CommandType == CType.EllipticalArc);
        }

        public bool IsUpper()
        {
            bool isUpper = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                //adjust isUpper
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (CommandType == CType.EllipticalArc)
            {
                if (relativeElements[5] == "1" && StartX <= EndX || relativeElements[5] == "0" && StartX >= EndX)
                {
                    isUpper = true;
                }
            }

            return isUpper;
        }

        public bool IsLower()
        {
            bool isLower = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                //adjust isLower
                throw new NotImplementedException("Not implemented for the command type");
            }

            if (CommandType == CType.EllipticalArc)
            {
                if (relativeElements[5] == "1" && StartX >= EndX || relativeElements[5] == "0" && StartX <= EndX)
                {
                    isLower = true;
                }
            }

            return isLower;
        }

        public bool IsRight()
        {
            bool isRight = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                //adjust isRight
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (CommandType == CType.EllipticalArc)
            {
                if (relativeElements[5] == "1" && StartY <= EndY || relativeElements[5] == "0" && StartY >= EndY)
                {
                    isRight = true;
                }
            }

            return isRight;
        }

        public bool IsLeft()
        {
            bool isLeft = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                //adjust isLeft
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (CommandType == CType.EllipticalArc)
            {
                if (relativeElements[5] == "1" && StartY >= EndY || relativeElements[5] == "0" && StartY <= EndY)
                {
                    isLeft = true;
                }
            }

            return isLeft;
        }

        public bool IsCircular()
        {
            bool isCircular = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (CommandType == CType.EllipticalArc)
            {
                isCircular = RadiusX == RadiusY;
            }

            return isCircular;
        }

        public bool IsHorizontal()
        {
            bool isHorizontal = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (CommandType == CType.EllipticalArc)
            {
                isHorizontal = StartY == EndY;
            }

            return isHorizontal;
        }

        public bool IsVertical()
        {
            bool isVertical = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(CommandType))
            {
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (CommandType == CType.EllipticalArc)
            {
                isVertical = StartX == EndX;
            }

            return isVertical;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            PathCommand c = (PathCommand)obj;
                        
            return c.StartX == StartX && 
                c.StartY == StartY && 
                c.GetRelativePath() == GetRelativePath();
        }
    }
}
