using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class LowerHalfCircleTest
    {
        private readonly ITestOutputHelper output;

        public LowerHalfCircleTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeCorrectShapeType()
        {
            LowerHalfCircle sut = new LowerHalfCircle(0, 0, 0);

            Assert.Equal(ShapeType.LowerHalfCircle, sut.ShapeType);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues()
        {
            int cx = 84;
            int cy = 64;
            int radius = 32;

            HalfCircle sut = new LowerHalfCircle(84, 64, 32);

            Assert.Equal(cx, sut.CX);            //x of half circle's center is not correct");
            Assert.Equal(cy, sut.CY);            //y of half circle's center is not correct");
            Assert.Equal(radius, sut.Radius);    //radius of half circle is not correct");
            Assert.Equal(cx - radius, sut.X);    //x of square of inscribed half circle is not correct");
            Assert.Equal(cy, sut.Y);             //y of square of inscribed half circle is not correct");
            Assert.Equal(radius * 2, sut.Width); //width of square of inscribed half circle is not correct");
            Assert.Equal(radius, sut.Height);    //height of square of inscribed half circle is not correct");
        }
    }
}
