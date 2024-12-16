using PAC5___Calculadora;
using System;
using Xunit;

namespace PAC5_Calculadora.Tests
{
    public class CalculadoraCoreTests
    {
        private readonly CalculadoraCore _calculadora;

        public CalculadoraCoreTests()
        {
            _calculadora = new CalculadoraCore();
        }

        [Fact]
        public void Test01_ComplexOperation_Success()
        {
            var result = _calculadora.Calcula("5 + 3 * 2 - 4 / 2");
            Assert.Equal("9", result);
        }

        [Fact]
        public void Test02_Power_Success()
        {
            var result = _calculadora.Calcula("2 ^ 3");
            Assert.Equal("8", result);
        }

        [Fact]
        public void Test03_PowerWithZero_Success()
        {
            var result = _calculadora.Calcula("0 ^ 5");
            Assert.Equal("0", result);
        }

        [Fact]
        public void Test04_SquareRoot_Success()
        {
            var result = _calculadora.Calcula("√ 16");
            Assert.Equal("4", result);
        }

        [Fact]
        public void Test05_SquareRootOfZero_Success()
        {
            var result = _calculadora.Calcula("√ 0");
            Assert.Equal("0", result);
        }

        [Fact]
        public void Test06_InvalidSquareRoot_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _calculadora.Calcula("3 √ 6"));
        }

        [Fact]
        public void Test07_MultiplyWithSquareRoot_Success()
        {
            var result = _calculadora.Calcula("3 * √ 9");
            Assert.Equal("9", result);
        }

        [Fact]
        public void Test08_NegativeSquareRoot_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _calculadora.Calcula("√ -4"));
        }

        [Fact]
        public void Test09_SimpleParentheses_Success()
        {
            var result = _calculadora.Calcula("( 5 + 3 ) * 2");
            Assert.Equal("16", result);
        }

        [Fact]
        public void Test10_NestedParentheses_Success()
        {
            var result = _calculadora.Calcula("( ( 2 + 3 ) * 2 )");
            Assert.Equal("10", result);
        }

        [Fact]
        public void Test11_UnmatchedOpenParentheses_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _calculadora.Calcula("5 + ( 3 * 2"));
        }

        [Fact]
        public void Test12_UnmatchedCloseParentheses_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _calculadora.Calcula("5 + 3 ) * 2"));
        }

        [Fact]
        public void Test13_ComplexExpressionWithAll_Success()
        {
            var result = _calculadora.Calcula("3 + 5 * ( 2 ^ 3 ) - √ 16");
            Assert.Equal("39", result);
        }

        [Fact]
        public void Test14_MissingOperatorBeforeParentheses_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _calculadora.Calcula("2(8 + 2)"));
        }

        [Fact]
        public void Test15_MissingOperatorAfterParentheses_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _calculadora.Calcula("(8 + 2)2"));
        }

        [Fact]
        public void Test16_ComplexExpressionWithAllRepeat_Success()
        {
            var result = _calculadora.Calcula("3 + 5 * ( 2 ^ 3 ) - √ 16");
            Assert.Equal("39", result);
        }

        [Fact]
        public void Test17_MissingOperatorBetweenParentheses_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _calculadora.Calcula("(5)3 + 2"));
        }

        [Fact]
        public void Test18_ExpressionWithSpaces_Success()
        {
            var result = _calculadora.Calcula("5        * 3 + 2");
            Assert.Equal("17", result);
        }
    }
}