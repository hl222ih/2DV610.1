using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

//using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

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
        public void CorrectPathTypeTest()
        {
            Line line = new Line(0, 0, 0, 0);
            Circle circle = new Circle(0, 0, 0);
            HalfCircle halfCircle = new HalfCircle();
            QuarterCircle quarterCircle = new QuarterCircle();
            EighthCircle eighthCircle = new EighthCircle();
            Heart heart = new Heart();

            Assert.True(line.ShapeType.Equals(ShapeType.Line));
            Assert.True(circle.ShapeType.Equals(ShapeType.Circle));
            Assert.True(halfCircle.ShapeType.Equals(ShapeType.HalfCircle));
            Assert.True(quarterCircle.ShapeType.Equals(ShapeType.QuarterCircle));
            Assert.True(eighthCircle.ShapeType.Equals(ShapeType.EighthCircle));
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
            //Available height is from 0 to 1280. Available width is from 0 to int.MaxValue
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(10, 20, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(20, 10, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1, 0, 0)); //cx < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0, -1, 0)); //cy < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0, 0, -1)); //radius < 0
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(641, 641, 641));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0, 1281, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(int.MaxValue - 9, 10, 10));
            //Accepted values does not throw an exception
            new Circle(0, 0, 0);
            new Circle(10, 10, 10);
            new Circle(20, 20, 11);
            new Circle(2560, 640, 640);
            new Circle(0, 1280, 0);
            new Circle(int.MaxValue - 10, 10, 10);
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
            Assert.True(line.X1.Equals(x2), "x of line's lower right edge is not correct");
            Assert.True(line.Y1.Equals(y2), "y of line's lower right edge is not correct");
            Assert.True(line.X.Equals(line.X1), "X and X1 should be equal");
            Assert.True(line.Y.Equals(line.Y1), "Y and Y1 should be equal");
            Assert.True(line.Width.Equals(width), "width of square of inscribed line is not correct");
            Assert.True(line.Height.Equals(height), "height of square of inscribed line is not correct");
            Assert.True(line.Length.Equals(hypotenuse), "line's length is not correct");            
        }
    }

}
