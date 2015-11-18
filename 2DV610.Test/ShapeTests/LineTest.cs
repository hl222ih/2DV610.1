using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class LineTest
    {
        private readonly ITestOutputHelper output;

        public LineTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeCorrectShapeType()
        {
            Line sut= new Line(0, 0, 0, 0);

            Assert.Equal(ShapeType.Line, sut.ShapeType);
        }

        [Fact]
        public void ValuesTest()
        {
            int x1 = 32;
            int y1 = 64;
            int x2 = 128;
            int y2 = 224;
            int width = x2 - x1;
            int height = y2 - y1;
            double hypotenuse = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

            Line line = new Line(x1, y1, x2, y2);
            Assert.Equal(x1, line.X1);                                   //x of line's upper left edge is not correct");
            Assert.Equal(y1, line.Y1);                                   //y of line's upper left edge is not correct");
            Assert.Equal(x2, line.X2);                                   //x of line's lower right edge is not correct");
            Assert.Equal(y2, line.Y2);                                   //y of line's lower right edge is not correct");
            Assert.Equal(line.X1 < line.X2 ? line.X1 : line.X2, line.X); //X and X1 or X2 (whichever is smallest) should be equal");
            Assert.Equal(line.Y1 < line.Y2 ? line.Y1 : line.Y2, line.Y); //Y and Y1 or Y2 (whichever is smallest) should be equal");
            Assert.Equal(width, line.Width);                             //width of square of inscribed line is not correct");
            Assert.Equal(height, line.Height);                           //height of square of inscribed line is not correct");
            Assert.Equal(hypotenuse, line.Length);                       //line's length is not correct");
        }

        [Theory]
        [InlineData(50, 50, 100, 100),
         InlineData(100, 100, 50, 50),
         InlineData(50, 100, 100, 50),
         InlineData(100, 50, 50, 100),
         InlineData(50, 50, 100, 50),
         InlineData(100, 50, 50, 50),
         InlineData(50, 50, 50, 100),
         InlineData(50, 100, 50, 50)]
        public void LineXYSwitchTest(int x1, int y1, int x2, int y2)
        {
            Line line = new Line(x1, y1, x2, y2);

            //X1,Y1 should be the leftmost coordinates of the line.
            //If the line is vertical, X1,Y1 should be the uppermost coordinates of the line.
            if (x1 > x2)
            {
                Assert.Equal(x2, line.X1);
                Assert.Equal(y2, line.Y1);
                Assert.Equal(x1, line.X2);
                Assert.Equal(y1, line.Y2);
            }
            else if (x1 < x2)
            {
                Assert.Equal(x1, line.X1);
                Assert.Equal(x2, line.X2);
                Assert.Equal(y1, line.Y1);
                Assert.Equal(y2, line.Y2);
            }
            else
            {
                Assert.Equal(x1, line.X1);
                Assert.Equal(x2, line.X2);
                if (y1 > y2)
                {
                    Assert.Equal(y2, line.Y1);
                    Assert.Equal(y1, line.Y2);
                }
                else
                {
                    Assert.Equal(y1, line.Y1);
                    Assert.Equal(y2, line.Y2);
                }
            }
            Assert.Equal(line.X1 < line.X2 ? line.X1 : line.X2, line.X); //X and X1 or X2 (whichever is smallest) should be equal");
            Assert.Equal(line.Y1 < line.Y2 ? line.Y1 : line.Y2, line.Y); //Y and Y1 or Y2 (whichever is smallest) should be equal");

        }

    }
}
