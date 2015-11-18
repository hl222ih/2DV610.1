using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class HeartTest
    {
        private readonly ITestOutputHelper output;

        public HeartTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeCorrectShapeType()
        {
            Heart sut = new Heart();

            Assert.Equal(ShapeType.Heart, sut.ShapeType);
        }

    }
}
