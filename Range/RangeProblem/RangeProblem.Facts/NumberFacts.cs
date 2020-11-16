using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            var number = new Number();

            var actual = number.Match("0");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            var number = new Number();

            var actual = number.Match("a");

            Assert.False(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            var number = new Number();

            var actual = number.Match("7");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            var number = new Number();

            var actual = number.Match("70");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsNotNull()
        {
            var number = new Number();

            var actual = number.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var number = new Number();

            var actual = number.Match(string.Empty);

            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void DoesNotStartWithZero()
        {
            var number = new Number();

            var actual = number.Match("07");

            Assert.True(actual.Success());
            Assert.Equal("7", actual.RemainingText());
        }

        [Fact]
        public void CanBeNegative()
        {
            var number = new Number();

            var actual = number.Match("-26");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanBeMinusZero()
        {
            var number = new Number();

            var actual = number.Match("-0");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanBeFractional()
        {
            var number = new Number();

            var actual = number.Match("12.34");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros1()
        {
            var number = new Number();

            var actual = number.Match("0.00000001");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros2()
        {
            var number = new Number();

            var actual = number.Match("10.00000001");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithADot()
        {
            var number = new Number();

            var actual = number.Match("12.");

            Assert.False(actual.Success());
            Assert.Equal(".", actual.RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            var number = new Number();

            var actual = number.Match("12.34.56");

            Assert.False(actual.Success());
            Assert.Equal(".56", actual.RemainingText());
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            var number = new Number();

            var actual = number.Match("12.3x");

            Assert.False(actual.Success());
            Assert.Equal("x", actual.RemainingText());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            var number = new Number();

            var actual = number.Match("12e3");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            var number = new Number();

            var actual = number.Match("12E3");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            var number = new Number();

            var actual = number.Match("12e+3");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void TheExponentCanBeNegative()
        {
            var number = new Number();

            var actual = number.Match("61e-9");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            var number = new Number();

            var actual = number.Match("12.34E");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void TheExponentDoesNotAllowLetters()
        {
            var number = new Number();

            var actual = number.Match("22e3x3");

            Assert.False(actual.Success());
            Assert.Equal("x3", actual.RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            var number = new Number();

            var actual = number.Match("22e323e33");

            Assert.False(actual.Success());
            Assert.Equal("e33", actual.RemainingText());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete1()
        {
            var number = new Number();

            var actual = number.Match("22e");

            Assert.False(actual.Success());
            Assert.Equal("e", actual.RemainingText());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete2()
        {
            var number = new Number();

            var actual = number.Match("22e+");

            Assert.False(actual.Success());
            Assert.Equal("+", actual.RemainingText());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete3()
        {
            var number = new Number();

            var actual = number.Match("23E-");

            Assert.False(actual.Success());
            Assert.Equal("-", actual.RemainingText());
        }

        [Fact]
        public void TheExponentIsAfterTheFraction()
        {
            var number = new Number();

            var actual = number.Match("22e3.3");

            Assert.False(actual.Success());
            Assert.Equal(".3", actual.RemainingText());
        }
    }
}
