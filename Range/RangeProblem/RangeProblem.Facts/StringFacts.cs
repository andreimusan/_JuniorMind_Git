using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class StringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted("abc"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            var stringValue = new String();

            var actual = stringValue.Match("abc\"");

            Assert.False(actual.Success());
            Assert.Equal("abc\"", actual.RemainingText());
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            var stringValue = new String();

            var actual = stringValue.Match("\"abc");

            Assert.False(actual.Success());
            Assert.Equal("\"abc", actual.RemainingText());
        }

        [Fact]
        public void IsNotNull()
        {
            var stringValue = new String();

            var actual = stringValue.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var stringValue = new String();

            var actual = stringValue.Match(string.Empty);

            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(string.Empty));

            Assert.True(actual.Success());
            Assert.Equal((string.Empty), actual.RemainingText());
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            var stringValue = new String();

            var actual = stringValue.Match("\"");

            Assert.False(actual.Success());
            Assert.Equal("\"", actual.RemainingText());
        }


        [Fact]
        public void DoesNotContainControlCharacters()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted("a\nb\rc"));

            Assert.False(actual.Success());
            Assert.Equal(Quoted("a\nb\rc"), actual.RemainingText());
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted("⛅⚾"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"\""a\"" b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \\ b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \/ b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \b b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \f b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \n b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \r b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \t b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a \u26Be b"));

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a\x"));

            Assert.False(actual.Success());
            Assert.Equal(@"\x", actual.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a\"));

            Assert.False(actual.Success());
            Assert.Equal(@"\", actual.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber1()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a\u"));

            Assert.False(actual.Success());
            Assert.Equal(@"\u", actual.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber2()
        {
            var stringValue = new String();

            var actual = stringValue.Match(Quoted(@"a\u123"));

            Assert.False(actual.Success());
            Assert.Equal(@"\u123", actual.RemainingText());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
