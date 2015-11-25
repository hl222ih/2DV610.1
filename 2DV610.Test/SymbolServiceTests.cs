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
            public List<Symbol> GetAllSymbols()
            {
                return new List<Symbol>();
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
    }
}
