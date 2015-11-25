using System;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;
using System.Collections.Generic;

namespace _2DV610.Test
{
    public class SymbolServiceTests
    {
        private readonly ITestOutputHelper output;

        public SymbolServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private class SymbolRepositoryMock : ISymbolRepository
        {

            List<Symbol> symbols;

            public List<Symbol> GetAllSymbols()
            {
                return symbols;
            }

            public void SetupSymbols(List<Symbol> symbols)
            {
                this.symbols = symbols;
            }
        }

        [Fact]
        public void ConstructorTest()
        {
            ISymbolRepository mock = new SymbolRepositoryMock();
            
            SymbolService sut = new SymbolService(mock);
        }

        [Fact]
        public void ConstructorShouldThrowNullArgumentExceptionIfPassedNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new SymbolService(null));
        }

        [Fact] void CountSymbolsShouldReturnCorrectCount()
        {
            SymbolRepositoryMock mock = new SymbolRepositoryMock();

            List<Symbol> symbols = new List<Symbol>()
            {
                new Symbol("M18,64 A32,32 0 0,1 82,64")
            };

            mock.SetupSymbols(symbols);

            SymbolService sut = new SymbolService(mock);

            Assert.Equal(1, sut.SymbolCount);
        }
    }
}
