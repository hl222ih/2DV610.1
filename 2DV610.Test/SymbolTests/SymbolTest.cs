using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using _2DV610;
using _2DV610.Classes;

namespace _2DV610.Test
{

    public class SymbolTest
    {
        private readonly ITestOutputHelper output;

        public SymbolTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Shape Stub that always returns true when HorizontallyTranslates() is called
        /// </summary>
        private class ShapeStub1 : Shape
        {
            public ShapeStub1() : base(ShapeType.Unspecified)
            {

            }

            public override string GetPath()
            {
                throw new NotImplementedException();
            }

            public override bool HorizontallyTranslates(Shape shape)
            {
                return true;
            }

        }

        /// <summary>
        /// Shape Stub that always returns false when HorizontallyTranslates() is called
        /// </summary>
        private class ShapeStub2 : Shape
        {
            public ShapeStub2() : base(ShapeType.Unspecified)
            {
            }

            public override string GetPath()
            {
                throw new NotImplementedException();
            }

            public override bool HorizontallyTranslates(Shape shape)
            {
                return false;
            }

        }

        /// <summary>
        /// Symbol Stub to simplify adding shapes to Symbol.
        /// </summary>
        private class SymbolStub : Symbol
        {
            public SymbolStub() : base("")
            {
                shapes = new List<Shape>();
            }

            public new void AddShape(Shape shape)
            {
                shapes.Add(shape);
            }
        }

        [Fact]
        public void ContainsShouldReturnTrueIfSymbolContainsShape()
        {
            Shape shape1 = new ShapeStub1();
            Shape shape2 = new ShapeStub2();
            SymbolStub sut = new SymbolStub();

            sut.AddShape(shape1);
            sut.AddShape(shape2);

            Assert.True(sut.Contains(shape1));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfSymbolDoesNotContainShape()
        {
            Shape shape1 = new ShapeStub1();
            Shape shape2 = new ShapeStub2();
            SymbolStub sut = new SymbolStub();

            sut.AddShape(shape2);

            Assert.False(sut.Contains(shape1));
        }

        //[Fact]
        //public void PathDataPassedToConstructorShouldReturnCorrectCommandCount()
        //{
        //    Symbol symbol = new Symbol("M18,64 A32,32 0 0,1 82,64");
        //    Assert.Equal(2, symbol.CommandCount);
        //}

        [Fact]
        public void ConstructorShouldInitializeInstanceVariables()
        {
            Symbol symbol = new Symbol("M18,64 A32,32 0 0,1 82,64");
            Assert.NotNull(symbol.Shapes);
            //Assert.NotNull(symbol.PathCommands);
            //Assert.NotNull(symbol.Symbols);
        }

    }
}
