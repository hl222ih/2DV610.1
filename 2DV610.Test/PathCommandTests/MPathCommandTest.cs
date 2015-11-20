using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class MPathCommandTest
    {
        private readonly ITestOutputHelper output;

        public MPathCommandTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MPathCommandTest_()
        {
            string svgPath1 = "M18,24";
            string svgPath2 = "m18,24";
            PathCommand command1 = new PathCommand(svgPath1);
            PathCommand command2 = new PathCommand(svgPath1, 10, 20);
            PathCommand command3 = new PathCommand(svgPath2);
            PathCommand command4 = new PathCommand(svgPath2, 10, 20);
            Assert.True(command1.GetRelativePath() == "m18,24");
            Assert.True(command1.GetAbsolutePath() == "M18,24");
            Assert.True(command2.GetRelativePath() == "m8,4");
            Assert.True(command2.GetAbsolutePath() == "M18,24");
            Assert.True(command3.GetRelativePath() == "m18,24");
            Assert.True(command3.GetAbsolutePath() == "M18,24");
            Assert.True(command4.GetRelativePath() == "m18,24");
            Assert.True(command4.GetAbsolutePath() == "M28,44");
        }

        [Fact]
        public void MPathCommandIsTest()
        {
            PathCommand command = new PathCommand("M18,24");
            Assert.True(command.IsMoveToCommand());
            Assert.False(command.IsArcCommand());
            Assert.False(command.IsUpper());
            Assert.False(command.IsLower());
            Assert.False(command.IsRight());
            Assert.False(command.IsLeft());
        }

        [Fact]
        public void MPathStartEndValuesTest()
        {
            string svgPath1 = "M18,24";
            string svgPath2 = "m18,24";
            PathCommand command1 = new PathCommand(svgPath1);
            PathCommand command2 = new PathCommand(svgPath1, 10, 20);
            PathCommand command3 = new PathCommand(svgPath2);
            PathCommand command4 = new PathCommand(svgPath2, 10, 20);
            Assert.True(command1.StartX == 0);
            Assert.True(command1.StartY == 0);
            Assert.True(command1.EndX == 18);
            Assert.True(command1.EndY == 24);
            Assert.True(command2.StartX == 10);
            Assert.True(command2.StartY == 20);
            Assert.True(command2.EndX == 18);
            Assert.True(command2.EndY == 24);
            Assert.True(command3.StartX == 0);
            Assert.True(command3.StartY == 0);
            Assert.True(command3.EndX == 18);
            Assert.True(command3.EndY == 24);
            Assert.True(command4.StartX == 10);
            Assert.True(command4.StartY == 20);
            Assert.True(command4.EndX == 28);
            Assert.True(command4.EndY == 44);
            Assert.True(command1.CenterX == 18);
            Assert.True(command1.CenterY == 24);
            Assert.True(command1.RadiusX == 0);
            Assert.True(command1.RadiusY == 0);
        }
    }
}
