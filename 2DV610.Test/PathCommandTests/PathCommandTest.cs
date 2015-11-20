using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{
    public class PathCommandTest
    {
        private readonly ITestOutputHelper output;

        public PathCommandTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void EqualsShouldReturnTrueOnSameValues1()
        {
            PathCommand command1 = new PathCommand("M64,32");
            PathCommand command2 = new PathCommand("m64,32");

            Assert.True(command1.Equals(command2));
        }

        [Fact]
        public void EqualsShouldReturnTrueOnSameValues2()
        {
            PathCommand command1 = new PathCommand("A32,16 0 1,0 10,64", 10, 10);
            PathCommand command2 = new PathCommand("a32,16 0 1,0 0,54", 10, 10);

            Assert.True(command1.Equals(command2));
        }
    }
}
