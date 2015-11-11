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
            Line line = new Line();
            Circle circle = new Circle(64, 64, 32);
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
            Circle circle = new Circle(64, 64, 32);
            Assert.True(circle.CX.Equals(64), "x of circle's center is not correct");
            Assert.True(circle.CY.Equals(64), "y of circle's center is not correct");
            Assert.True(circle.Radius.Equals(32), "radius of circle is not correct");
            Assert.True(circle.X.Equals(32), "x of square of inscribed circle is not correct");
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

    }

}
