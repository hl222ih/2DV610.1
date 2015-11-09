//using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;
using System;

//using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace _2DV610.Test
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CorrectPathTypeTest()
        {
            Line line = new Line("");
            Circle circle = new Circle("");
            HalfCircle halfCircle = new HalfCircle("");
            QuarterCircle quarterCircle = new QuarterCircle("");
            EighthCircle eighthCircle = new EighthCircle("");
            Heart heart = new Heart("");

            Assert.True(line.GetPathType().Equals(PathType.Line));
            Assert.True(circle.GetPathType().Equals(PathType.Circle));
            Assert.True(halfCircle.GetPathType().Equals(PathType.HalfCircle));
            Assert.True(quarterCircle.GetPathType().Equals(PathType.QuarterCircle));
            Assert.True(eighthCircle.GetPathType().Equals(PathType.EighthCircle));
            Assert.True(heart.GetPathType().Equals(PathType.Heart));
        }
    }
}
