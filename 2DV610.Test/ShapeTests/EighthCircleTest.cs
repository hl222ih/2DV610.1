using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class EighthCircleTest
    {
        private readonly ITestOutputHelper output;

        public EighthCircleTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeCorrectShapeType()
        {
            EighthCircle sut = new EighthCircle();

            Assert.Equal(ShapeType.EighthCircle, sut.ShapeType);
        }

    }
}
