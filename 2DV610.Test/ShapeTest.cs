using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    /// <summary>
    /// All shapes must fit into a box defined by (x = 0, y = 0, height = 1280, width = 128000).
    /// This test suite tests that when X, Y, Width or Height is set in such a way that the Shapes circumscribed box
    /// would be placed outside the allowed box, an ArgumentOutOfRangeException is thrown.
    /// </summary>
    public class ShapeTest
    {
        private class ShapeMock : Shape
        {
            public ShapeMock() : base(ShapeType.Unspecified)
            {
            }

            public void SetX(int x)
            {
                X = x;
            }

            public void SetY(int y)
            {
                Y = y;
            }

            public void SetWidth(int width)
            {
                Width = width;
            }

            public void SetHeight(int height)
            {
                Height = height;
            }

            public override string GetPath()
            {
                throw new NotImplementedException();
            }

            public override bool HorizontallyTranslates(Shape shape)
            {
                throw new NotImplementedException();
            }
        }

        private readonly ITestOutputHelper output;

        public ShapeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void XOutsideValidBoxShouldThrowArgumentOutOfRangeException1()
        {
            ShapeMock sut = new ShapeMock();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetX(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetX(128001));
            //allowed x values (given a 0 value on width) should not throw an exception
            sut.SetX(0);
            sut.SetX(128000);
        }

        [Fact]
        public void XOutsideValidBoxShouldThrowArgumentOutOfRangeException2()
        {
            ShapeMock sut = new ShapeMock();
            sut.SetWidth(127990);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetX(11));
            //allowed x values (given a certain width value) should not throw an exception
            sut.SetX(10);
        }

        [Fact]
        public void YOutsideValidBoxShouldThrowArgumentOutOfRangeException1()
        {
            ShapeMock sut = new ShapeMock();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetY(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetY(1281));
            //allowed y values (given a 0 value on height) should not throw an exception
            sut.SetY(0);
            sut.SetY(1280);
        }

        [Fact]
        public void YOutsideValidBoxShouldThrowArgumentOutOfRangeException2()
        {
            ShapeMock sut = new ShapeMock();
            sut.SetHeight(1270);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetY(11));
            //allowed y values (given a certain height value) should not throw an exception
            sut.SetY(10);
        }

        [Fact]
        public void WidthOutsideValidBoxShouldThrowArgumentOutOfRangeException1()
        {
            ShapeMock sut = new ShapeMock();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetWidth(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetWidth(128001));
            //allowed width values (given a 0 value on x) should not throw an exception
            sut.SetWidth(0);
            sut.SetWidth(128000);
        }

        [Fact]
        public void WidthOutsideValidBoxShouldThrowArgumentOutOfRangeException2()
        {
            ShapeMock sut = new ShapeMock();
            sut.SetX(127990);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetWidth(11));
            //allowed width values (given a certain x value) should not throw an exception
            sut.SetWidth(10);
        }

        [Fact]
        public void HeightOutsideValidBoxThrowsArgumentOutOfRangeException1()
        {
            ShapeMock sut = new ShapeMock();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetHeight(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetHeight(1281));
            //allowed height values (given a 0 value on y) should not throw an exception
            sut.SetHeight(0);
            sut.SetHeight(1280);
        }

        [Fact]
        public void HeightOutsideValidBoxThrowsArgumentOutOfRangeException2()
        {
            ShapeMock sut = new ShapeMock();
            sut.SetY(1270);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetHeight(11));
            //allowed height values (given a certain y value) should not throw an exception
            sut.SetHeight(10);
        }
    }
}