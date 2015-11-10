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

            Assert.True(line.PathType.Equals(ShapeType.Line));
            Assert.True(circle.PathType.Equals(ShapeType.Circle));
            Assert.True(halfCircle.PathType.Equals(ShapeType.HalfCircle));
            Assert.True(quarterCircle.PathType.Equals(ShapeType.QuarterCircle));
            Assert.True(eighthCircle.PathType.Equals(ShapeType.EighthCircle));
            Assert.True(heart.PathType.Equals(ShapeType.Heart));
        }

        //[Fact]
        //public void InvalidLineArgumentsThrowsArgumentException()
        //{
        //    Assert.Throws<ArgumentException>(() => new Line(""));
        //    Assert.Throws<ArgumentException>(() => new Line("R 0 0 0 0"));
        //    Assert.Throws<ArgumentException>(() => new Line("L 0 0 0 0"));
        //    Assert.Throws<ArgumentException>(() => new Line("L 0 0 64 64 64"));
        //    Assert.Throws<ArgumentException>(() => new Line("L 0 64 64"));
        //}
    }

}
