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
        public void ConstructorOfUpperLeftQShouldSetCorrectValues()
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
        public void ConstructorOfUpperRightQShouldSetCorrectValues()
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
        public void ConstructorOfLowerLeftQShouldSetCorrectValues()
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

        [Fact]
        public void ConstructorOfLowerRightQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            int radius = 32;

            QuarterCircle sut = new LowerRightQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.LowerRightQuarterCircle, sut.ShapeType);
            Assert.Equal(cx, sut.X);
            Assert.Equal(cy, sut.Y);
            Assert.Equal(radius, sut.Width);
            Assert.Equal(radius, sut.Height);
        }

        [Fact]
        public void ConstructorOfUpperQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            float radius = (float)(Math.Sqrt(2) * 32); //≈45.254833

            QuarterCircle sut = new UpperQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.UpperQuarterCircle, sut.ShapeType);
            Assert.Equal(48, sut.Radius);
            Assert.Equal(cx - 32, sut.X);
            Assert.Equal(cy - 16, sut.Y);
            Assert.Equal(cy - radius, ((UpperQuarterCircle)sut).Y);
            Assert.Equal(64, sut.Width);
            Assert.Equal(16, sut.Height); // 1/4 of Width
            Assert.Equal(radius-32, ((UpperQuarterCircle)sut).Height);
        }

        [Fact]
        public void ConstructorOfLowerQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            float radius = (float)(Math.Sqrt(2) * 32); //≈45.254833

            QuarterCircle sut = new LowerQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.LowerQuarterCircle, sut.ShapeType);
            Assert.Equal(48, sut.Radius);
            Assert.Equal(cx - 32, sut.X);
            Assert.Equal(cy, sut.Y);
            Assert.Equal(64, sut.Width);
            Assert.Equal(16, sut.Height); // 1/4 of Width
            Assert.Equal(radius - 32, ((LowerQuarterCircle)sut).Height);
        }

        [Fact]
        public void ConstructorOfLeftQShouldSetCorrectValues()
        {
            int cx = 64;
            int cy = 64;
            float radius = (float)(Math.Sqrt(2) * 32); //≈45.254833

            QuarterCircle sut = new LeftQuarterCircle(cx, cy, radius);

            Assert.Equal(ShapeType.LeftQuarterCircle, sut.ShapeType);
            Assert.Equal(48, sut.Radius);
            Assert.Equal(cx - 16, sut.X);
            Assert.Equal(cx - radius, ((LeftQuarterCircle)sut).X);
            Assert.Equal(cy - 32, sut.Y);
            Assert.Equal(16, sut.Width); // 1/4 of Height
            Assert.Equal(radius - 32, ((LeftQuarterCircle)sut).Width);
            Assert.Equal(64, sut.Height); 
        }

    }
}
