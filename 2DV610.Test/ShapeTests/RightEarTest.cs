using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class RightEarTest
    {
        private readonly ITestOutputHelper output;

        public RightEarTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeCorrectShapeType()
        {
            RightEar sut = new RightEar(0, 0);

            Assert.Equal(ShapeType.RightEar, sut.ShapeType);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues()
        {
            int x = 32;
            int y = 64;
            int width = 256;
            int height = 512;

            RightEar sut = new RightEar(x, y);
            Assert.Equal(x, sut.X);
            Assert.Equal(y, sut.Y);
            Assert.Equal(width, sut.Width);
            Assert.Equal(height, sut.Height);

            Assert.Equal(y, sut.TopY);
            Assert.Equal(y + height / 4, sut.MidY);
            Assert.Equal(y + height, sut.BottomY);
            Assert.Equal(x, sut.LeftX);
            Assert.Equal(x + width, sut.RightX);
        }
    }
}
