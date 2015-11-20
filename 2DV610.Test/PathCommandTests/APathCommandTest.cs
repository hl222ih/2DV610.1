using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class APathCommandTest
    {
        private readonly ITestOutputHelper output;

        public APathCommandTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetPathShouldReturnCorrectPath1()
        {
            string path = "A32,32 0 0,1 82,64";
            PathCommand sut = new PathCommand(path);
            Assert.True(sut.GetRelativePath() == "a32,32 0 0,1 82,64");
            Assert.True(sut.GetAbsolutePath() == "A32,32 0 0,1 82,64");
        }

        [Fact]
        public void GetPathShouldReturnCorrectPath2()
        {
            string path = "A32,32 0 0,1 82,64";
            PathCommand sut = new PathCommand(path, 10, 20);
            Assert.True(sut.GetRelativePath() == "a32,32 0 0,1 72,44");
            Assert.True(sut.GetAbsolutePath() == "A32,32 0 0,1 82,64");
        }

        [Fact]
        public void GetPathShouldReturnCorrectPath3()
        {
            string path = "a32,32 0 0,1 64,0";
            PathCommand sut = new PathCommand(path);
            Assert.True(sut.GetRelativePath() == "a32,32 0 0,1 64,0");
            Assert.True(sut.GetAbsolutePath() == "A32,32 0 0,1 64,0");
        }

        [Fact]
        public void GetPathShouldReturnCorrectPath4()
        {
            string path = "a32,32 0 0,1 64,0";
            PathCommand sut = new PathCommand(path, 10, 20);
            Assert.True(sut.GetRelativePath() == "a32,32 0 0,1 64,0");
            Assert.True(sut.GetAbsolutePath() == "A32,32 0 0,1 74,20");
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues1()
        {
            string path = "A32,32 0 0,1 82,64";
            PathCommand sut = new PathCommand(path);

            Assert.Equal(0, sut.StartX);
            Assert.Equal(0, sut.StartY);
            Assert.Equal(82, sut.EndX);
            Assert.Equal(64, sut.EndY);
            Assert.Equal(41, sut.CenterX);
            Assert.Equal(32, sut.CenterY);
            Assert.Equal(32, sut.RadiusX);
            Assert.Equal(32, sut.RadiusY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues2()
        {
            string path = "A32,32 0 0,1 82,64";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.StartX);
            Assert.Equal(20, sut.StartY);
            Assert.Equal(82, sut.EndX);
            Assert.Equal(64, sut.EndY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues3()
        {
            string path = "a32,32 0 0,1 -64,0";
            PathCommand sut = new PathCommand(path);

            Assert.Equal(0, sut.StartX);
            Assert.Equal(0, sut.StartY);
            Assert.Equal(-64, sut.EndX);
            Assert.Equal(0, sut.EndY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues4()
        {
            string path = "a32,32 0 0,1 -64,0";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.StartX);
            Assert.Equal(20, sut.StartY);
            Assert.Equal(-54, sut.EndX);
            Assert.Equal(20, sut.EndY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues5()
        {
            string path = "a32,32 0 0,1 32,32";
            PathCommand sut = new PathCommand(path);

            Assert.Equal(0, sut.CenterX);
            Assert.Equal(32, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues6()
        {
            string path = "a32,32 0 1,0 32,32";
            PathCommand sut = new PathCommand(path);

            Assert.Equal(32, sut.CenterX);
            Assert.Equal(32, sut.CenterY);
        }

        [Fact]
        public void APathCommandIsUpperLowerTest()
        {
            PathCommand command1 = new PathCommand("A32,32 0 0,1 64,0");
            PathCommand command2 = new PathCommand("a32,32 0 0,1 64,0");
            PathCommand command3 = new PathCommand("a32,32 0 0,1 -64,0");
            PathCommand command4 = new PathCommand("A32,32 0 1,0 64,0");
            PathCommand command5 = new PathCommand("a32,32 0 1,0 64,0");
            PathCommand command6 = new PathCommand("a32,32 0 1,0 -64,0");
            PathCommand command7 = new PathCommand("a32,32 0 1,0 0,64");
            PathCommand command8 = new PathCommand("a32,32 0 1,0 0,-64");
            Assert.False(command1.IsMoveToCommand());
            Assert.True(command1.IsArcCommand());
            Assert.True(command1.IsUpper());
            Assert.False(command1.IsLower());
            Assert.True(command2.IsUpper());
            Assert.False(command2.IsLower());
            Assert.False(command3.IsUpper());
            Assert.True(command3.IsLower());
            Assert.False(command4.IsUpper());
            Assert.True(command4.IsLower());
            Assert.False(command5.IsUpper());
            Assert.True(command5.IsLower());
            Assert.True(command6.IsUpper());
            Assert.False(command6.IsLower());
            Assert.True(command7.IsUpper());
            Assert.True(command7.IsLower());
            Assert.True(command8.IsUpper());
            Assert.True(command8.IsLower());
        }

        [Fact]
        public void APathCommandIsRightLeftTest()
        {
            PathCommand command1 = new PathCommand("A32,32 0 0,1 0,64");
            PathCommand command2 = new PathCommand("a32,32 0 0,1 0,64");
            PathCommand command3 = new PathCommand("a32,32 0 0,1 0,-64");
            PathCommand command4 = new PathCommand("A32,32 0 1,0 0,64");
            PathCommand command5 = new PathCommand("a32,32 0 1,0 0,64");
            PathCommand command6 = new PathCommand("a32,32 0 1,0 0,-64");
            PathCommand command7 = new PathCommand("a32,32 0 1,0 64,0");
            PathCommand command8 = new PathCommand("a32,32 0 1,0 -64,0");
            Assert.True(command1.IsRight());
            Assert.False(command1.IsLeft());
            Assert.True(command2.IsRight());
            Assert.False(command2.IsLeft());
            Assert.False(command3.IsRight());
            Assert.True(command3.IsLeft());
            Assert.False(command4.IsRight());
            Assert.True(command4.IsLeft());
            Assert.False(command5.IsRight());
            Assert.True(command5.IsLeft());
            Assert.True(command6.IsRight());
            Assert.False(command6.IsLeft());
            Assert.True(command7.IsRight());
            Assert.True(command8.IsLeft());
            Assert.True(command7.IsRight());
            Assert.True(command8.IsLeft());
        }

        [Fact]
        public void APathCommandIsCircularVerticalHorizontalTest()
        {
            //line in the shape of a lower half circle, clockwise from left to right, horizontal (line between start y and end y) 
            PathCommand command1 = new PathCommand("a32,32 0 0,1 64,0");
            //like above, but elliptic with half the radius.
            PathCommand command2 = new PathCommand("a32,16 0 0,1 64,0");
            //line in the shape of a right half ellipse (half radius compared to circle), counter-clockwise from top to bottom, vertical (line between start x and end x)
            PathCommand command3 = new PathCommand("a32,16 0 1,0 0,64");
            //like above but a right half circle
            PathCommand command4 = new PathCommand("a32,32 0 1,0 0,64");

            Assert.True(command1.IsCircular());
            Assert.False(command2.IsCircular());
            Assert.False(command3.IsCircular());
            Assert.True(command4.IsCircular());
            Assert.True(command1.IsHorizontal());
            Assert.True(command2.IsHorizontal());
            Assert.False(command3.IsHorizontal());
            Assert.False(command4.IsHorizontal());
            Assert.False(command1.IsVertical());
            Assert.False(command2.IsVertical());
            Assert.True(command3.IsVertical());
            Assert.True(command4.IsVertical());
        }
    }
}
