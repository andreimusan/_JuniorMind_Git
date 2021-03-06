﻿using System;

namespace RangeProblem
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            // aici construiește patternul pentru
            // un JSON value
            // ai grijă să ți seama de `spații albe`
            var stringValue = new String();
            var number = new Number();

            var value = new Choice(
                            stringValue,
                            number,
                            new Text("true"),
                            new Text("false"),
                            new Text("null"));

            var quote = new Character('"');
            var openBracket = new Character('[');
            var closeBracket = new Character(']');
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(','), whitespace);

            var element = new Sequence(whitespace, value, whitespace);
            var elements = new List(element, separator);

            var array = new Sequence(openBracket, whitespace, elements, closeBracket);
            value.Add(array);

            var openCurlyBracket = new Character('{');
            var closeCurlyBracket = new Character('}');

            var member = new Sequence(whitespace, stringValue, whitespace, new Character(':'), element);
            var members = new List(member, separator);

            var objectValue = new Sequence(openCurlyBracket, whitespace, members, closeCurlyBracket);
            value.Add(objectValue);

            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
