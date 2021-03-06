﻿using System;
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
        /// Symbol Stub to simplify adding shapes to Symbol, access to protected methods etc.
        /// </summary>
        private class SymbolStub : Symbol
        {
            public SymbolStub(string path) : base(path)
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
            SymbolStub sut = new SymbolStub("");

            sut.AddShape(shape1);
            sut.AddShape(shape2);

            Assert.True(sut.Contains(shape1));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfSymbolDoesNotContainShape()
        {
            Shape shape1 = new ShapeStub1();
            Shape shape2 = new ShapeStub2();
            SymbolStub sut = new SymbolStub("");

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
            Assert.NotNull(symbol.PathCommands);
            Assert.NotNull(symbol.Symbols);
        }
        
        [Fact]
        public void ConstructorShouldCreateTwoSymbolsForATwoSymbolPath()
        {
            //two circles made of two lower half circles combined with two upper half circles
            Symbol sut = new Symbol("M0,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0 M640,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0");
            Assert.Equal(2, sut.Symbols.Length);
            Assert.Equal(ShapeType.Circle, sut.Symbols[0].Shapes[0].ShapeType);
            //two circles made of one lower half circle + upper half circle and one upper half circle + one lower half circle
            sut = new Symbol("M0,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0 M640,768a256,256 0 0,1 512,0a256,256 0 0,1 -512,0");
            Assert.Equal(2, sut.Symbols.Length);
            //two circles, one made of a left half circle + a right half circle. the second one upper half circle + one lower half circle
            sut = new Symbol("M256,512a256,256 0 1,0 0,512a256,256 0 1,0 0,-512 M640,768a256,256 0 0,1 512,0a256,256 0 0,1 -512,0");
            Assert.Equal(1, sut.Symbols[0].Shapes.Length);
            Assert.Equal(ShapeType.Circle, sut.Symbols[0].Shapes[0].ShapeType);
            Assert.True(sut.Symbols[0].Shapes[0].HorizontallyTranslates(sut.Symbols[1].Shapes[0]));
        }

        [Fact]
        public void SymbolOfOneSymbolShouldNotContainSubSymbols()
        {
            Symbol sut = new Symbol("M0,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0");
            Assert.Equal(0, sut.Symbols.Length);
        }

        [Fact]
        public void SymbolOfMultipleSymbolsShouldContainSymbol()
        {
            Symbol sutTwoSymbols = new Symbol("M0,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0 M640,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0");
            Symbol sutOneSymbol = new Symbol("M0,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0");
            Assert.True(sutTwoSymbols.Contains(sutOneSymbol));
            Assert.False(sutOneSymbol.Contains(sutTwoSymbols));
            Symbol sutOneSymbolOffset = new Symbol("M128,768a256,256 0 1,0 512,0a256,256 0 1,0 -512,0");
            Assert.Equal(0, sutOneSymbolOffset.Symbols.Length);
            Assert.True(sutTwoSymbols.Contains(sutOneSymbolOffset));
        }

        //        [Fact]
        //        public void ConstructorShouldCreatePathCommandsAsIndividuallyCreated()
        //        {
        //            Symbol sut = new Symbol("M84,64 a32,32 0 0,1 -10,64");
        //            PathCommand[] commands = sut.PathCommands;

        //            PathCommand command1 = new PathCommand("M84, 64");
        //            //PathCommand command2 = new PathCommand("M84, 64");

        //            Assert.True(command1.Equals(commands[0]));
        ////            Assert.Equal("a32,32 0 0,1 -10,64", paths[1]);
        //        }

        [Fact]
        public void CreatePathCommandsShouldCreatePathCommandsWithCorrectInParameters()
        {
            //SymbolStub sut = new SymbolStub("");
            //string[] paths = new string[] { "M18,64", "a32,32 0 0,1 64,32" };

            //sut.CreatePathCommands(paths);

            //Assert.Equal(2, sut.PathCommands.Length);
            //Assert.Equal(18, sut.PathCommands[0].EndX);
            //Assert.Equal(64, sut.PathCommands[0].EndY);
            //Assert.True(sut.PathCommands[0].IsMoveToCommand());
            //Assert.Equal(82, sut.PathCommands[1].EndX);
            //Assert.Equal(96, sut.PathCommands[1].EndY);
            //Assert.Equal(32, sut.PathCommands[1].RadiusX);
            //Assert.Equal(32, sut.PathCommands[1].RadiusY);
            //Assert.True(sut.PathCommands[1].IsArcCommand());
        }
    }
}
