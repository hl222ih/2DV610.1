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
        private enum CType
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

        private CType type;

        private string[] relativeElements;
        private string[] absoluteElements;

        public float StartX { get; private set; }
        public float StartY { get; private set; }
        public float EndX { get; private set; }
        public float EndY { get; private set; }

        public float CenterX
        {
            get
            {
                float cx = 0;

                switch (type)
                {
                    case CType.MoveTo:
                        cx = EndX;
                        break;
                    default:
                    break;
                }

                return cx;
            }
        }
        public float CenterY
        {
            get
            {
                float cy = 0;

                switch (type)
                {
                    case CType.MoveTo:
                        cy = EndY;
                        break;
                    default:
                        break;
                }

                return cy;
            }
        }
        public float RadiusX
        {
            get
            {
                float rx = 0;

                switch (type)
                {
                    case CType.EllipticalArc:
                        rx = -1; //add logic
                        break;
                    default:
                        break;
                }

                return rx;
            }
        }
        public float RadiusY
        {
            get
            {
                float ry = 0;

                switch (type)
                {
                    case CType.EllipticalArc:
                        ry = -1; //add logic
                        break;
                    default:
                        break;
                }

                return ry;
            }
        }

        public PathCommand(string svgCommandPath, float startX = 0, float startY = 0)
        {
            StartX = startX;
            StartY = startY;
            string[] elems = ParsePathElements(svgCommandPath);
            AdjustElementsValues(elems);
        }

        private string[] ParsePathElements(string svgPath)
        {
            //match path elements that are valid path commands and floats
            MatchCollection matchList = Regex.Matches(svgPath, @"([MmZzLlHhVvCcSsQqTtAa]|\-?\d+(?:\.\d+)?)");
            string[] elems = matchList.Cast<Match>().Select(match => match.Value).ToArray();

            return elems;
        }

        private void AdjustElementsValues(string[] elems)
        {
            relativeElements = (string[])elems.Clone();
            absoluteElements = (string[])elems.Clone();

            relativeElements[0] = elems[0].ToLower();
            absoluteElements[0] = elems[0].ToUpper();
            
            switch (elems[0])
            {
                case "M":
                    type = CType.MoveTo;
                    EndX = float.Parse(elems[1]);
                    EndY = float.Parse(elems[2]);
                    relativeElements[1] = (EndX - StartX).ToString();
                    relativeElements[2] = (EndY - StartY).ToString();
                    break;
                case "m":
                    type = CType.MoveTo;
                    EndX = float.Parse(elems[1]) + StartX;
                    EndY = float.Parse(elems[2]) + StartY;
                    absoluteElements[1] = EndX.ToString();
                    absoluteElements[2] = EndY.ToString();
                    break;
                case "A":
                    type = CType.EllipticalArc;
                    EndX = float.Parse(elems[6]);
                    EndY = float.Parse(elems[7]);
                    relativeElements[6] = (EndX - StartX).ToString();
                    relativeElements[7] = (EndY - StartY).ToString();
                    break;
                case "a":
                    type = CType.EllipticalArc;
                    EndX = float.Parse(elems[6]) + StartX;
                    EndY = float.Parse(elems[7]) + StartY;
                    absoluteElements[6] = EndX.ToString();
                    absoluteElements[7] = EndY.ToString();
                    break;
                default:
                    type = CType.Undefined;
                    break;
            }

        }

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
            return (type == CType.MoveTo);
        }

        public bool IsArcCommand()
        {
            return (type == CType.EllipticalArc);
        }

        public bool IsUpper()
        {
            bool isUpper = false;
            CType[] undefined = new CType[] { CType.Undefined, CType.CurveTo, CType.ShorthandCurveTo, CType.QuadraticCurveTo, CType.QuadraticCurveTo, CType.ShorthandQuadraticCurveTo };

            if (undefined.Contains(type))
            {
                //adjust isUpper
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (type == CType.EllipticalArc)
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

            if (undefined.Contains(type))
            {
                //adjust isLower
                throw new NotImplementedException("Not implemented for the command type");
            }

            if (type == CType.EllipticalArc)
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

            if (undefined.Contains(type))
            {
                //adjust isRight
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (type == CType.EllipticalArc)
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

            if (undefined.Contains(type))
            {
                //adjust isLeft
                throw new NotImplementedException("Not implemented for the command type");
            }
            if (type == CType.EllipticalArc)
            {
                if (relativeElements[5] == "1" && StartY >= EndY || relativeElements[5] == "0" && StartY <= EndY)
                {
                    isLeft = true;
                }
            }

            return isLeft;
        }

    }
}
