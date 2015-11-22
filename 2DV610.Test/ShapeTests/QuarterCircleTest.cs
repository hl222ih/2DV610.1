using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class QuarterCircleTest
    {
        private readonly ITestOutputHelper output;

        public QuarterCircleTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        //[Fact]
        //public void ShouldBeCorrectShapeType()
        //{
        //    QuarterCircle sut = new QuarterCircle();

        //    Assert.Equal(ShapeType.QuarterCircle, sut.ShapeType);
        //}

        [Fact]
        public void ConstructorShouldSetCorrectValues()
        {
            int cx = 84;
            int cy = 64;
            int radius = 32;

            QuarterCircle sut = new UpperLeftQuarterCircle(cx, cy, radius);

            Assert.Equal(cx, sut.CX);            
            Assert.Equal(cy, sut.CY);            
            Assert.Equal(radius, sut.Radius);
        }

        [Fact]
        public void NegativeRadiusThrowsArgumentOutOfRangeException()
        {
            int cx = 84;
            int cy = 64;
            int radius = -32;

            Assert.Throws<ArgumentOutOfRangeException>(() => new UpperLeftQuarterCircle(cx, cy, radius));
        }

        [Fact]
        public void ConstructorOfULQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            int radius = 32;
            
            QuarterCircle sut = new UpperLeftQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.UpperLeftQuarterCircle, sut.ShapeType);
            Assert.Equal(cx - radius, sut.X);        
            Assert.Equal(cy - radius, sut.Y);        
            Assert.Equal(radius, sut.Width);         
            Assert.Equal(radius, sut.Height);    
        }

        [Fact]
        public void ConstructorOfURQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            int radius = 32;

            QuarterCircle sut = new UpperRightQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.UpperRightQuarterCircle, sut.ShapeType);
            Assert.Equal(cx, sut.X);
            Assert.Equal(cy - radius, sut.Y);
            Assert.Equal(radius, sut.Width);
            Assert.Equal(radius, sut.Height);
        }

        [Fact]
        public void ConstructorOfLLQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            int radius = 32;

            QuarterCircle sut = new LowerLeftQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.LowerLeftQuarterCircle, sut.ShapeType);
            Assert.Equal(cx - radius, sut.X);
            Assert.Equal(cy, sut.Y);
            Assert.Equal(radius, sut.Width);
            Assert.Equal(radius, sut.Height);
        }

    }
}
