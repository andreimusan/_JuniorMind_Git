using System;
using Xunit;

namespace RangeProblem.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match(string.Empty);
            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("012");
            Assert.True(actual.Success());
            Assert.Equal("12", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("12");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit3()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("92");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("a9");
            Assert.False(actual.Success());
            Assert.Equal("a9", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("012");
            Assert.True(actual.Success());
            Assert.Equal("12", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("12");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex3()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("92");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex4()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("a9");
            Assert.True(actual.Success());
            Assert.Equal("9", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex5()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("f8");
            Assert.True(actual.Success());
            Assert.Equal("8", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex6()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("A9");
            Assert.True(actual.Success());
            Assert.Equal("9", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex7()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("F8");
            Assert.True(actual.Success());
            Assert.Equal("8", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidHex1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("g8");
            Assert.False(actual.Success());
            Assert.Equal("g8", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidHex2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("G8");
            Assert.False(actual.Success());
            Assert.Equal("G8", actual.RemainingText());
        }

        [Fact]
        public void IsNotNullHex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyHexString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match(string.Empty);
            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidIntValue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var intValue = new Choice(
                        new Choice(
                            new Character('-')
                        ),
                        digit
                    );

            var actual = intValue.Match("12");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidNegativeIntValue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var intValue = new Choice(
                        new Choice(
                            new Character('-')
                        ),
                        digit
                    );

            var actual = intValue.Match("-12");
            Assert.True(actual.Success());
            Assert.Equal("12", actual.RemainingText());
        }

        [Fact]
        public void IsValidArrayValue()
        {
            var stringValue = new String();
            var number = new Number();

            var value = new Choice(
                            stringValue,
                            number,
                            new Text("true"),
                            new Text("false"),
                            new Text("null")
                        );

            var quote = new Character('"');
            var openBracket = new Character('[');
            var closeBracket = new Character(']');
            var space = new Character(Convert.ToChar(0020));
            var horizontalTabulation = new Character(Convert.ToChar(0009));
            var ws = new Choice(new Sequence(quote, quote), space, horizontalTabulation);

            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Character(','));

            var array = new Choice(new Sequence(openBracket, ws, closeBracket), new Sequence(openBracket, elements, closeBracket));
            value.Add(array);

            var openCurlyBracket = new Character('{');
            var closeCurlyBracket = new Character('}');

            var member = new Sequence(ws, stringValue, ws, new Character(':'), element);
            var members = new List(member, new Character(','));

            var objectValue = new Choice(new Sequence(openCurlyBracket, ws, closeCurlyBracket), new Sequence(openCurlyBracket, members, closeCurlyBracket));
            value.Add(objectValue);

            var actual = value.Match("[12]");
            Assert.True(actual.Success());
            Assert.Equal("12]", actual.RemainingText());
        }
    }
}
