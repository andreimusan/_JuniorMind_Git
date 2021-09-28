using LinqExercitii;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinqExeritii.Facts
{
    public class ReversePolishNotationFacts
    {
        [Fact]
        public void Test_ReversePolishNotationSimple()
        {
            var expression = "3 4 + 5 2 - *";

            Assert.Equal(21, ReversePolishNotation.PolishNotation(expression));
        }

        [Fact]
        public void Test_ReversePolishNotationMedium()
        {
            var expression = "5 1 2 + 4 * + 3 -";

            Assert.Equal(14, ReversePolishNotation.PolishNotation(expression));
        }

        [Fact]
        public void Test_ReversePolishNotationComplex()
        {
            var expression = "15 7 1 1 + - / 3 * 2 1 1 + + -";

            Assert.Equal(5, ReversePolishNotation.PolishNotation(expression));
        }
    }
}
