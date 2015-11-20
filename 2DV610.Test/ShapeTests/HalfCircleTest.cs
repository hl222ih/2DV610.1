using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class HalfCircleTest
    {
        private readonly ITestOutputHelper output;

        public HalfCircleTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TranslationTest()
        {
            //Translation is when two shapes have the same size and form but might be differently positioned.
            HalfCircle sut1 = new LeftHalfCircle(50, 64, 32);
            HalfCircle sut2 = new LeftHalfCircle(100, 64, 32);
            HalfCircle sut3 = new LeftHalfCircle(50, 84, 32);
            HalfCircle sut4 = new RightHalfCircle(100, 64, 32);

            Assert.True(sut1.HorizontallyTranslates(sut2), "horizontal translation between the half circles should be true.");
            Assert.True(sut2.HorizontallyTranslates(sut1), "horizontal translation between the half circles should be true.");
            Assert.False(sut3.HorizontallyTranslates(sut1), "horizontal translation between the half circles should be false.");
            Assert.False(sut4.HorizontallyTranslates(sut1), "horizontal translation between the half circles should be false.");
        }

        [Fact]
        public void EqualsTest()
        {
            HalfCircle sut1 = new LeftHalfCircle(50, 64, 32);
            HalfCircle sut2 = new LeftHalfCircle(50, 64, 32);
            HalfCircle sut3 = new LeftHalfCircle(100, 64, 32);

            Assert.True(sut1.Equals(sut2));
            Assert.False(sut1.Equals(sut3));
        }

    }
}

