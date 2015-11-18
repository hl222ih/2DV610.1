using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{

    public class XUnitTest1
    {
        private readonly ITestOutputHelper output;

        public XUnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SymbolOfLowerHalfCircleTest()
        {
            Shape shape = new LowerHalfCircle(50, 64, 32);

            Symbol symbol1 = new Symbol("M18,64 A 32,32 0 1,0 82,64"); //absolute left to right
            Symbol symbol2 = new Symbol("M18,64 a 32,32 0 1,0 64,0");  //relative left to right
            Symbol symbol3 = new Symbol("M82,64 A 32,32 0 0,1 18,64"); //absolute right to left
            Symbol symbol4 = new Symbol("M82,64 a 32,32 0 0,1 -64,0"); //relative right to left
            Assert.True(symbol1.Contains(shape));
            Assert.True(symbol2.Contains(shape));
            Assert.True(symbol3.Contains(shape));
            Assert.True(symbol4.Contains(shape));
        }

        [Fact]
        public void SymbolOfUpperHalfCircleTest()
        {
            Shape shape = new UpperHalfCircle(50, 64, 32);

            Symbol symbol1 = new Symbol("M18,64 A 32,32 0 0,1 82,64"); //absolute left to right
            Symbol symbol2 = new Symbol("M18,64 a 32,32 0 0,1 64,0");  //relative left to right
            Symbol symbol3 = new Symbol("M82,64 A 32,32 0 1,0 18,64"); //absolute right to left
            Symbol symbol4 = new Symbol("M82,64 a 32,32 0 1,0 -64,0"); //relative right to left
            Assert.True(symbol1.Contains(shape));
            Assert.True(symbol2.Contains(shape));
            Assert.True(symbol3.Contains(shape));
            Assert.True(symbol4.Contains(shape));
        }

        [Fact]
        public void SymbolOfLeftHalfCircleTest()
        {
            Shape shape = new LeftHalfCircle(50, 96, 32);

            Symbol symbol1 = new Symbol("M82,64 A 32,32 0 1,0 82,128"); //absolute upper to lower
            Symbol symbol2 = new Symbol("M82,64 a 32,32 0 1,0 0,64");   //relative upper to lower
            Symbol symbol3 = new Symbol("M82,128 A 32,32 0 0,1 82,64"); //absolute lower to upper
            Symbol symbol4 = new Symbol("M82,128 a 32,32 0 0,1 0,-64"); //relative lower to upper
            Assert.True(symbol1.Contains(shape));
            Assert.True(symbol2.Contains(shape));
            Assert.True(symbol3.Contains(shape));
            Assert.True(symbol4.Contains(shape));
        }

        [Fact]
        public void SymbolOfRightHalfCircleTest()
        {
            Shape shape = new RightHalfCircle(50, 96, 32);

            Symbol symbol1 = new Symbol("M82,64 A 32,32 0 0,1 82,128"); //absolute upper to lower
            Symbol symbol2 = new Symbol("M82,64 a 32,32 0 0,1 0,64");   //relative upper to lower
            Symbol symbol3 = new Symbol("M82,128 A 32,32 0 1,0 82,64"); //absolute lower to upper
            Symbol symbol4 = new Symbol("M82,128 a 32,32 0 1,0 0,-64"); //relative lower to upper
            Assert.True(symbol1.Contains(shape));
            Assert.True(symbol2.Contains(shape));
            Assert.True(symbol3.Contains(shape));
            Assert.True(symbol4.Contains(shape));
        }

        [Fact]
        public void SymbolTest()
        {
            Symbol symbol = new Symbol("M18,64 A32,32 0 0,1 82,64");
            Assert.True(symbol.CommandCount == 2);
        }
    }
}
