using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class CircleTest
    {
        private readonly ITestOutputHelper output;

        public CircleTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeCorrectShapeType()
        {
            Circle sut = new Circle(0, 0, 0);

            Assert.Equal(ShapeType.Circle, sut.ShapeType);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues()
        {
            int cx = 84;
            int cy = 64;
            int radius = 32;

            Circle sut = new Circle(cx, cy, radius);

            Assert.Equal(cx, sut.CX);               //x of circle's center is not correct
            Assert.Equal(cy, sut.CY);               //y of circle's center is not correct
            Assert.Equal(radius, sut.Radius);       //radius of circle is not correct
            Assert.Equal(cx - radius, sut.X);       //x of square of inscribed circle is not correct
            Assert.Equal(cy - radius, sut.Y);       //y of square of inscribed circle is not correct
            Assert.Equal(radius * 2, sut.Width);    //width of square of inscribed circle is not correct
            Assert.Equal(radius * 2, sut.Height);   //height of square of inscribed circle is not correct
            Assert.Equal(radius * 2, sut.Diameter); //diameter of circle is not correct");
        }

        [Fact]
        public void ConstructorsEqualityTest()
        {
            Circle circle1 = new Circle(84, 64, 32);
            Circle circle2 = new Circle(52, 32, 64, false);
            Assert.True(circle1.Equals(circle2), "the circles should be equal");
            Assert.Equal(circle1.GetHashCode(), circle2.GetHashCode()); //the circles should generate the same hash code
        }

        [Fact]
        public void TranslationTest()
        {
            //Translation is when two shapes have the same size and form but might be differently positioned.
            Circle circle1 = new Circle(50, 64, 32);
            Circle circle2 = new Circle(100, 64, 32);
            Assert.True(circle1.HorizontallyTranslates(circle2), "horizontal translation between the circles should be true.");
            Assert.True(circle2.HorizontallyTranslates(circle1), "horizontal translation between the circles should be true.");
        }

        [Fact]
        public void GetPathTest()
        {
            Circle circle1 = new Circle(50, 64, 32);
            //Assert.True(circle1.GetPath().Equals("M18,64a32,32 0 1,0 64,0a32,32 0 1,0 -64,0"), "didn't return the correct path string.");
            Assert.Equal("M18,64A32,32 0 1,0 82,64A32,32 0 1,0 18,64", circle1.GetPath()); //didn't return the correct path string.");
        }

    }
}
