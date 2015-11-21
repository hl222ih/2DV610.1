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
            //Half circle left to right, clockwise
            string path = "A32,32 0 0,1 74,20";
            PathCommand sut = new PathCommand(path,10,20);

            Assert.Equal(10, sut.StartX);
            Assert.Equal(20, sut.StartY);
            Assert.Equal(74, sut.EndX);
            Assert.Equal(20, sut.EndY);
            Assert.Equal(42, sut.CenterX);
            Assert.Equal(20, sut.CenterY);
            Assert.Equal(32, sut.RadiusX);
            Assert.Equal(32, sut.RadiusY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues2()
        {
            //Half circle right to left, clockwise
            string path = "A32,32 0 0,1 -54,-20";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.StartX);
            Assert.Equal(20, sut.StartY);
            Assert.Equal(-54, sut.EndX);
            Assert.Equal(-20, sut.EndY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues3()
        {
            //Half circle right to left, clockwise
            string path = "a32,32 0 0,1 -64,0";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.StartX);
            Assert.Equal(20, sut.StartY);
            Assert.Equal(-54, sut.EndX);
            Assert.Equal(20, sut.EndY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues4()
        {
            //Half circle right to left, clockwise
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
            //Quarter circle upper left to lower right, clockwise
            string path = "a32,32 0 0,1 32,32";
            PathCommand sut = new PathCommand(path, 10, 20);
            
            Assert.Equal(10, sut.CenterX);
            Assert.Equal(52, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues6()
        {
            //Quarter circle upper left to lower right, counter-clockwise
            string path = "a32,32 0 0,0 32,32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(42, sut.CenterX);
            Assert.Equal(20, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues7()
        {
            //Quarter circle upper right to lower left, clockwise
            string path = "a32,32 0 0,1 -32,32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(-22, sut.CenterX);
            Assert.Equal(20, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues8()
        {
            //Quarter circle upper right to lower left, counter-clockwise
            string path = "a32,32 0 0,0 -32,32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.CenterX);
            Assert.Equal(52, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues9()
        {
            //Quarter circle lower right to upper left, counter-clockwise
            string path = "a32,32 0 0,0 -32,-32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(-22, sut.CenterX);
            Assert.Equal(20, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues10()
        {
            //Quarter circle lower right to upper left, clockwise
            string path = "a32,32 0 0,1 -32,-32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.CenterX);
            Assert.Equal(-12, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues11()
        {
            //Quarter circle lower left to upper right, clockwise
            string path = "a32,32 0 0,1 32,-32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(10, sut.CenterX);
            Assert.Equal(-12, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues12()
        {
            //Quarter circle lower left to upper right, counter-clockwise
            string path = "a32,32 0 0,0 32,-32";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(42, sut.CenterX);
            Assert.Equal(20, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues13()
        {
            //Quarter circle, horizontal, left to right, clockwise
            float radius = (float)(Math.Sqrt(2) * 32);
            string path = "a"+radius+","+radius+" 0 0,1 32,0";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(26, sut.CenterX);
            Assert.Equal(36, sut.CenterY);
        }

        [Fact]
        public void ConstructorShouldSetCorrectValues14()
        {
            //Quarter circle, horizontal, left to right, counter-clockwise
            float radius = (float)(Math.Sqrt(2) * 32);
            string path = "a" + radius + "," + radius + " 0 0,0 32,0";
            PathCommand sut = new PathCommand(path, 10, 20);

            Assert.Equal(26, sut.CenterX);
            Assert.Equal(4, sut.CenterY);
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
