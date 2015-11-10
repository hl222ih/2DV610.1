﻿using System;
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
            Line line = new Line("L 0 0 64 64");
            Circle circle = new Circle("");
            HalfCircle halfCircle = new HalfCircle("");
            QuarterCircle quarterCircle = new QuarterCircle("");
            EighthCircle eighthCircle = new EighthCircle("");
            Heart heart = new Heart("");

            Assert.True(line.GetPathType().Equals(ShapeType.Line));
            Assert.True(circle.GetPathType().Equals(ShapeType.Circle));
            Assert.True(halfCircle.GetPathType().Equals(ShapeType.HalfCircle));
            Assert.True(quarterCircle.GetPathType().Equals(ShapeType.QuarterCircle));
            Assert.True(eighthCircle.GetPathType().Equals(ShapeType.EighthCircle));
            Assert.True(heart.GetPathType().Equals(ShapeType.Heart));
        }

        [Fact]
        public void InvalidLineArgumentsThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Line(""));
            Assert.Throws<ArgumentException>(() => new Line("R 0 0 0 0"));
            Assert.Throws<ArgumentException>(() => new Line("L 0 0 0 0"));
            Assert.Throws<ArgumentException>(() => new Line("L 0 0 64 64 64"));
            Assert.Throws<ArgumentException>(() => new Line("L 0 64 64"));
        }
    }

}
