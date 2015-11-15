using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{

    public class XUnitTest1
    {
        private readonly ITestOutputHelper output;

        public XUnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CorrectShapeTypeTest()
        {
            Line line = new Line(0, 0, 0, 0);
            Circle circle = new Circle(0, 0, 0);
            LeftHalfCircle leftHalfCircle = new LeftHalfCircle(0, 0, 0);
            RightHalfCircle rightHalfCircle = new RightHalfCircle(0, 0, 0);
            UpperHalfCircle upperHalfCircle = new UpperHalfCircle(0, 0, 0);
            LowerHalfCircle lowerHalfCircle = new LowerHalfCircle(0, 0, 0);
            QuarterCircle quarterCircle = new QuarterCircle();
            EighthCircle eighthCircle = new EighthCircle();
            LeftEar leftEar = new LeftEar(0,0);
            RightEar rightEar = new RightEar(0,0);
            Heart heart = new Heart();

            Assert.True(line.ShapeType.Equals(ShapeType.Line));
            Assert.True(circle.ShapeType.Equals(ShapeType.Circle));
            Assert.True(leftHalfCircle.ShapeType.Equals(ShapeType.LeftHalfCircle));
            Assert.True(rightHalfCircle.ShapeType.Equals(ShapeType.RightHalfCircle));
            Assert.True(upperHalfCircle.ShapeType.Equals(ShapeType.UpperHalfCircle));
            Assert.True(lowerHalfCircle.ShapeType.Equals(ShapeType.LowerHalfCircle));
            Assert.True(quarterCircle.ShapeType.Equals(ShapeType.QuarterCircle));
            Assert.True(eighthCircle.ShapeType.Equals(ShapeType.EighthCircle));
            Assert.True(leftEar.ShapeType.Equals(ShapeType.LeftEar));
            Assert.True(rightEar.ShapeType.Equals(ShapeType.RightEar));
            Assert.True(heart.ShapeType.Equals(ShapeType.Heart));
        }

        [Fact]
        public void CircleValuesTest()
        {
            Circle circle = new Circle(84, 64, 32);
            Assert.True(circle.CX.Equals(84), "x of circle's center is not correct");
            Assert.True(circle.CY.Equals(64), "y of circle's center is not correct");
            Assert.True(circle.Radius.Equals(32), "radius of circle is not correct");
            Assert.True(circle.X.Equals(52), "x of square of inscribed circle is not correct");
            Assert.True(circle.Y.Equals(32), "y of square of inscribed circle is not correct");
            Assert.True(circle.Width.Equals(64), "width of square of inscribed circle is not correct");
            Assert.True(circle.Height.Equals(64), "height of square of inscribed circle is not correct");
            Assert.True(circle.Diameter.Equals(64), "diameter of circle is not correct");
        }

        [Fact]
        public void CircleOutsideInputDomainThrowsArgumentOutOfRangeException()
        {
            //Available height is from 0 to 1280. Available width is from 0 to 128000.
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(10, 20, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(20, 10, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1, 0, 0)); //cx < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0, -1, 0)); //cy < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0, 0, -1)); //radius < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(640, 641, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(641, 640, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0, 1281, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(128000 - 9, 10, 10));
            //Accepted values does not throw an exception
            new Circle(0, 0, 0);
            new Circle(10, 10, 10);
            new Circle(20, 20, 11);
            new Circle(2560, 640, 640);
            new Circle(0, 1280, 0);
            new Circle(128000 - 10, 10, 10);
        }

        [Fact]
        public void LineValuesTest()
        {
            int x1 = 32;
            int y1 = 64;
            int x2 = 128;
            int y2 = 224;
            int width = x2 - x1;
            int height = y2 - y1;
            double hypotenuse = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

            Line line = new Line(x1, y1, x2, y2);
            Assert.True(line.X1.Equals(x1), "x of line's upper left edge is not correct");
            Assert.True(line.Y1.Equals(y1), "y of line's upper left edge is not correct");
            Assert.True(line.X2.Equals(x2), "x of line's lower right edge is not correct");
            Assert.True(line.Y2.Equals(y2), "y of line's lower right edge is not correct");
            Assert.True(line.X.Equals(line.X1 < line.X2 ? line.X1 : line.X2 ), "X and X1 or X2 (whichever is smallest) should be equal");
            Assert.True(line.Y.Equals(line.Y1 < line.Y2 ? line.Y1 : line.Y2), "Y and Y1 or Y2 (whichever is smallest) should be equal");
            Assert.True(line.Width.Equals(width), "width of square of inscribed line is not correct");
            Assert.True(line.Height.Equals(height), "height of square of inscribed line is not correct");
            Assert.True(line.Length.Equals(hypotenuse), "line's length is not correct");
        }

        [Theory]
        [InlineData(50, 50, 100, 100),
         InlineData(100, 100, 50, 50),
         InlineData(50, 100, 100, 50),
         InlineData(100, 50, 50, 100),
         InlineData(50, 50, 100, 50),
         InlineData(100, 50, 50, 50),
         InlineData(50, 50, 50, 100),
         InlineData(50, 100, 50, 50)]
        public void LineXYSwitchTest(int x1, int y1, int x2, int y2)
        {
            Line line = new Line(x1, y1, x2, y2);

            //X1,Y1 should be the leftmost coordinates of the line.
            //If the line is vertical, X1,Y1 should be the uppermost coordinates of the line.
            if (x1 > x2)
            {
                Assert.True(line.X1.Equals(x2));
                Assert.True(line.Y1.Equals(y2));
                Assert.True(line.X2.Equals(x1));
                Assert.True(line.Y2.Equals(y1));
            }
            else if (x1 < x2)
            {
                Assert.True(line.X1.Equals(x1));
                Assert.True(line.X2.Equals(x2));
                Assert.True(line.Y1.Equals(y1));
                Assert.True(line.Y2.Equals(y2));
            }
            else
            {
                Assert.True(line.X1.Equals(x1));
                Assert.True(line.X2.Equals(x2));
                if (y1 > y2)
                {
                    Assert.True(line.Y1.Equals(y2));
                    Assert.True(line.Y2.Equals(y1));
                }
                else
                {
                    Assert.True(line.Y1.Equals(y1));
                    Assert.True(line.Y2.Equals(y2));
                }
            }
            Assert.True(line.X.Equals(line.X1 < line.X2 ? line.X1 : line.X2), "X and X1 or X2 (whichever is smallest) should be equal");
            Assert.True(line.Y.Equals(line.Y1 < line.Y2 ? line.Y1 : line.Y2), "Y and Y1 or Y2 (whichever is smallest) should be equal");

        }

        [Fact]
        public void LineOutsideInputDomainThrowsArgumentOutOfRangeException()
        {
            //Available height is from 0 to 1280. Width from 0 to 128000.
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(-1, 0, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(0, -1, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(0, 0, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(0, 0, 0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(128001, 0, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(0, 1281, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(0, 0, 128001, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Line(0, 0, 0, 1281));
            //Accepted values does not throw an exception
            new Line(0, 0, 128000, 1280);
            new Line(0, 1280, 128000, 0);
            new Line(128000, 0, 0, 1280);
            new Line(128000, 1280, 0, 0);
        }

        [Fact]
        public void CircleConstructorsEqualityTest()
        {
            Circle circle1 = new Circle(84, 64, 32);
            Circle circle2 = new Circle(52, 32, 64, false);
            Assert.True(circle1.Equals(circle2), "the circles should be equal");
            Assert.True(circle1.GetHashCode() == circle2.GetHashCode(), "the circles should generate the same hash code");
        }

        [Fact]
        public void CircleTranslationTest()
        {
            //Translation is when two shapes have the same size and form but might be differently positioned.
            Circle circle1 = new Circle(50, 64, 32);
            Circle circle2 = new Circle(100, 64, 32);
            Assert.True(circle1.HorizontallyTranslates(circle2), "horizontal translation between the circles should be true.");
            Assert.True(circle2.HorizontallyTranslates(circle1), "horizontal translation between the circles should be true.");
        }

        [Fact]
        public void CircleGetPathTest()
        {
            Circle circle1 = new Circle(50, 64, 32);
            //Assert.True(circle1.GetPath().Equals("M18,64a32,32 0 1,0 64,0a32,32 0 1,0 -64,0"), "didn't return the correct path string.");
            Assert.True(circle1.GetPath().Equals("M18,64A32,32 0 1,0 82,64A32,32 0 1,0 18,64"), "didn't return the correct path string.");
        }

        [Fact]
        public void LeftHalfCircleValuesTest()
        {
            HalfCircle halfCircle = new LeftHalfCircle(84, 64, 32);
            Assert.True(halfCircle.CX.Equals(84), "x of half circle's center is not correct");
            Assert.True(halfCircle.CY.Equals(64), "y of half circle's center is not correct");
            Assert.True(halfCircle.Radius.Equals(32), "radius of half circle is not correct");
            Assert.True(halfCircle.X.Equals(52), "x of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Y.Equals(32), "y of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Width.Equals(32), "width of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Height.Equals(64), "height of square of inscribed half circle is not correct");
        }

        [Fact]
        public void LeftHalfCircleOutsideInputDomainThrowsArgumentOutOfRangeException()
        {
            //Available height is from 0 to 1280. Available width is from 0 to 128000.
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(10, 20, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(20, 10, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(-1, 0, 0)); //cx < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(0, -1, 0)); //cy < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(0, 0, -1)); //radius < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(641, 640, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(640, 641, 640));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(0, 1281, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeftHalfCircle(128001, 0, 0));
            //Accepted values does not throw an exception
            new LeftHalfCircle(0, 0, 0);
            new LeftHalfCircle(640, 640, 640);
            new LeftHalfCircle(20, 20, 11);
            new LeftHalfCircle(2560, 640, 640);
            new LeftHalfCircle(0, 1280, 0);
            new LeftHalfCircle(128000, 100, 100);
        }

        [Fact]
        public void RightHalfCircleValuesTest()
        {
            HalfCircle halfCircle = new RightHalfCircle(84, 64, 32);
            Assert.True(halfCircle.CX.Equals(84), "x of half circle's center is not correct");
            Assert.True(halfCircle.CY.Equals(64), "y of half circle's center is not correct");
            Assert.True(halfCircle.Radius.Equals(32), "radius of half circle is not correct");
            Assert.True(halfCircle.X.Equals(84), "x of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Y.Equals(32), "y of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Width.Equals(32), "width of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Height.Equals(64), "height of square of inscribed half circle is not correct");
        }

        [Fact]
        public void RightHalfCircleOutsideInputDomainThrowsArgumentOutOfRangeException()
        {
            //Available height is from 0 to 1280. Available width is from 0 to 128000.
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(20, 10, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(-1, 0, 0)); //cx < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(0, -1, 0)); //cy < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(0, 0, -1)); //radius < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(0, 640, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(0, 641, 640));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(0, 1281, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RightHalfCircle(128000, 1, 1));
            //Accepted values does not throw an exception
            new RightHalfCircle(0, 0, 0);
            new RightHalfCircle(0, 640, 640);
            new RightHalfCircle(0, 11, 11);
            new RightHalfCircle(2560, 640, 640);
            new RightHalfCircle(0, 1280, 0);
            new RightHalfCircle(127900, 100, 100);
        }

        [Fact]
        public void UpperHalfCircleValuesTest()
        {
            HalfCircle halfCircle = new UpperHalfCircle(84, 64, 32);
            Assert.True(halfCircle.CX.Equals(84), "x of half circle's center is not correct");
            Assert.True(halfCircle.CY.Equals(64), "y of half circle's center is not correct");
            Assert.True(halfCircle.Radius.Equals(32), "radius of half circle is not correct");
            Assert.True(halfCircle.X.Equals(52), "x of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Y.Equals(32), "y of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Width.Equals(64), "width of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Height.Equals(32), "height of square of inscribed half circle is not correct");
        }

        [Fact]
        public void UpperHalfCircleOutsideInputDomainThrowsArgumentOutOfRangeException()
        {
            //Available height is from 0 to 1280. Available width is from 0 to 128000.
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(10, 20, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(20, 10, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(-1, 0, 0)); //cx < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(0, -1, 0)); //cy < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(0, 0, -1)); //radius < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(641, 640, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(640, 639, 640));
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(0, 1281, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperHalfCircle(128000, 1, 1));
            //Accepted values does not throw an exception
            new UpperHalfCircle(0, 0, 0);
            new UpperHalfCircle(640, 1280, 640);
            new UpperHalfCircle(10, 10, 10);
            new UpperHalfCircle(2560, 640, 640);
            new UpperHalfCircle(0, 1280, 0);
            new UpperHalfCircle(127900, 100, 100);
        }

        [Fact]
        public void LowerHalfCircleValuesTest()
        {
            HalfCircle halfCircle = new LowerHalfCircle(84, 64, 32);
            Assert.True(halfCircle.CX.Equals(84), "x of half circle's center is not correct");
            Assert.True(halfCircle.CY.Equals(64), "y of half circle's center is not correct");
            Assert.True(halfCircle.Radius.Equals(32), "radius of half circle is not correct");
            Assert.True(halfCircle.X.Equals(52), "x of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Y.Equals(64), "y of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Width.Equals(64), "width of square of inscribed half circle is not correct");
            Assert.True(halfCircle.Height.Equals(32), "height of square of inscribed half circle is not correct");
        }

        [Fact]
        public void LowerHalfCircleOutsideInputDomainThrowsArgumentOutOfRangeException()
        {
            //Available height is from 0 to 1280. Available width is from 0 to 128000.
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(10, 20, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(-1, 0, 0)); //cx < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(0, -1, 0)); //cy < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(0, 0, -1)); //radius < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(641, 640, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(640, 641, 640));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(1, 1280, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LowerHalfCircle(128000, 1, 1));
            //Accepted values does not throw an exception
            new LowerHalfCircle(0, 0, 0);
            new LowerHalfCircle(640, 0, 640);
            new LowerHalfCircle(1270, 1270, 10);
            new LowerHalfCircle(2560, 640, 640);
            new LowerHalfCircle(0, 1280, 0);
            new LowerHalfCircle(127900, 1180, 100);
        }

        [Fact]
        public void LeftEarValuesTest()
        {
            int x = 32;
            int y = 64;
            const int Width = 256;
            const int Height = 512;

            LeftEar leftEar = new LeftEar(x, y);
            Assert.True(leftEar.X.Equals(x));
            Assert.True(leftEar.Y.Equals(y));
            Assert.True(leftEar.Width.Equals(Width));
            Assert.True(leftEar.Height.Equals(Height));

            Assert.True(leftEar.TopY.Equals(y));
            Assert.True(leftEar.MidY.Equals(y + Height / 4));
            Assert.True(leftEar.BottomY.Equals(y + Height));
            Assert.True(leftEar.LeftX.Equals(x));
            Assert.True(leftEar.RightX.Equals(x + Width));
        }

        [Fact]
        public void RightEarValuesTest()
        {
            int x = 32;
            int y = 64;
            const int Width = 256;
            const int Height = 512;

            RightEar rightEar = new RightEar(x, y);
            Assert.True(rightEar.X.Equals(x));
            Assert.True(rightEar.Y.Equals(y));
            Assert.True(rightEar.Width.Equals(Width));
            Assert.True(rightEar.Height.Equals(Height));

            Assert.True(rightEar.TopY.Equals(y));
            Assert.True(rightEar.MidY.Equals(y + Height / 4));
            Assert.True(rightEar.BottomY.Equals(y + Height));
            Assert.True(rightEar.LeftX.Equals(x));
            Assert.True(rightEar.RightX.Equals(x + Width));
        }


        [Fact]
        public void SymbolOfLowerHalfCircleTest()
        {
            Shape shape = new LowerHalfCircle(50, 64, 32);

            Symbol symbol1 = new Symbol("M18,64 A 32,32 0 0,0 82,64"); //absolute left to right
            Symbol symbol2 = new Symbol("M18,64 a 32,32 0 0,0 64,0"); //relative left to right
            Symbol symbol3 = new Symbol("M82,64 A 32,32 0 0,1 18,64"); //absolute right to left
            Symbol symbol4 = new Symbol("M82,64 a 32,32 0 0,1 -64,0"); //relative right to left
            Assert.True(symbol1.Contains(shape));
            Assert.True(symbol2.Contains(shape));
            Assert.True(symbol3.Contains(shape));
            Assert.True(symbol4.Contains(shape));
        }

        [Fact]
        public void SymbolOfUpperHalfCircleTest()
        {
            Shape shape = new UpperHalfCircle(50, 64, 32);

            Symbol symbol1 = new Symbol("M18,64 A 32,32 0 0,1 82,64"); //absolute left to right
            Symbol symbol2 = new Symbol("M18,64 a 32,32 0 0,1 64,0"); //relative left to right
            Symbol symbol3 = new Symbol("M82,64 A 32,32 0 0,0 18,64"); //absolute right to left
            Symbol symbol4 = new Symbol("M82,64 a 32,32 0 0,0 -64,0"); //relative right to left
            Assert.True(symbol1.Contains(shape));
            Assert.True(symbol2.Contains(shape));
            Assert.True(symbol3.Contains(shape));
            Assert.True(symbol4.Contains(shape));
        }

        [Fact]
        public void SvgTest()
        {
            Svg svg = new Svg("M18,64 A32,32 0 0,1 82,64");
            Assert.True(svg.CommandCount == 2);
        }

        [Fact]
        public void MPathCommandTest()
        {
            string svgPath1 = "M18,24";
            string svgPath2 = "m18,24";
            PathCommand command1 = new PathCommand(svgPath1);
            PathCommand command2 = new PathCommand(svgPath1, 10, 20);
            PathCommand command3 = new PathCommand(svgPath2);
            PathCommand command4 = new PathCommand(svgPath2, 10, 20);
            Assert.True(command1.GetRelativePath() == "m18,24");
            Assert.True(command1.GetAbsolutePath() == "M18,24");
            Assert.True(command2.GetRelativePath() == "m8,4");
            Assert.True(command2.GetAbsolutePath() == "M18,24");
            Assert.True(command3.GetRelativePath() == "m18,24");
            Assert.True(command3.GetAbsolutePath() == "M18,24");
            Assert.True(command4.GetRelativePath() == "m18,24");
            Assert.True(command4.GetAbsolutePath() == "M28,44");
        }

        [Fact]
        public void MPathCommandIsTest()
        {
            PathCommand command = new PathCommand("M18,24");
            Assert.True(command.IsMoveToCommand());
            Assert.False(command.IsArcCommand());
            Assert.False(command.IsUpper());
            Assert.False(command.IsLower());
            Assert.False(command.IsRight());
            Assert.False(command.IsLeft());
        }

        [Fact]
        public void MPathStartEndValuesTest()
        {
            string svgPath1 = "M18,24";
            string svgPath2 = "m18,24";
            PathCommand command1 = new PathCommand(svgPath1);
            PathCommand command2 = new PathCommand(svgPath1, 10, 20);
            PathCommand command3 = new PathCommand(svgPath2);
            PathCommand command4 = new PathCommand(svgPath2, 10, 20);
            Assert.True(command1.StartX == 0);
            Assert.True(command1.StartY == 0);
            Assert.True(command1.EndX == 18);
            Assert.True(command1.EndY == 24);
            Assert.True(command2.StartX == 10);
            Assert.True(command2.StartY == 20);
            Assert.True(command2.EndX == 18);
            Assert.True(command2.EndY == 24);
            Assert.True(command3.StartX == 0);
            Assert.True(command3.StartY == 0);
            Assert.True(command3.EndX == 18);
            Assert.True(command3.EndY == 24);
            Assert.True(command4.StartX == 10);
            Assert.True(command4.StartY == 20);
            Assert.True(command4.EndX == 28);
            Assert.True(command4.EndY == 44);
            Assert.True(command1.CenterX == 18);
            Assert.True(command1.CenterY == 24);
            Assert.True(command1.RadiusX == 0);
            Assert.True(command1.RadiusY == 0);
        }

        [Fact]
        public void APathCommandTest()
        {
            string svgPath1 = "A32,32 0 0,1 82,64";
            string svgPath2 = "a32,32 0 0,1 64,0";
            PathCommand command1 = new PathCommand(svgPath1);
            PathCommand command2 = new PathCommand(svgPath1, 10, 20);
            PathCommand command3 = new PathCommand(svgPath2);
            PathCommand command4 = new PathCommand(svgPath2, 10, 20);
            Assert.True(command1.GetRelativePath() == "a32,32 0 0,1 82,64");
            Assert.True(command1.GetAbsolutePath() == "A32,32 0 0,1 82,64");
            Assert.True(command2.GetRelativePath() == "a32,32 0 0,1 72,44");
            Assert.True(command2.GetAbsolutePath() == "A32,32 0 0,1 82,64");
            Assert.True(command3.GetRelativePath() == "a32,32 0 0,1 64,0");
            Assert.True(command3.GetAbsolutePath() == "A32,32 0 0,1 64,0");
            Assert.True(command4.GetRelativePath() == "a32,32 0 0,1 64,0");
            Assert.True(command4.GetAbsolutePath() == "A32,32 0 0,1 74,20");
        }

        [Fact]
        public void APathStartEndValuesTest()
        {
            string svgPath1 = "A32,32 0 0,1 82,64";
            string svgPath2 = "a32,32 0 0,1 64,0";
            PathCommand command1 = new PathCommand(svgPath1);
            PathCommand command2 = new PathCommand(svgPath1, 10, 20);
            PathCommand command3 = new PathCommand(svgPath2);
            PathCommand command4 = new PathCommand(svgPath2, 10, 20);
            Assert.True(command1.StartX == 0);
            Assert.True(command1.StartY == 0);
            Assert.True(command1.EndX == 82);
            Assert.True(command1.EndY == 64);
            Assert.True(command2.StartX == 10);
            Assert.True(command2.StartY == 20);
            Assert.True(command2.EndX == 82);
            Assert.True(command2.EndY == 64);
            Assert.True(command3.StartX == 0);
            Assert.True(command3.StartY == 0);
            Assert.True(command3.EndX == 64);
            Assert.True(command3.EndY == 0);
            Assert.True(command4.StartX == 10);
            Assert.True(command4.StartY == 20);
            Assert.True(command4.EndX == 74);
            Assert.True(command4.EndY == 20);
        }
    }
}
