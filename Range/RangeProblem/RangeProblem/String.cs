using System;

namespace RangeProblem
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            // aici construiește patternul pentru
            // un JSON string
            var quote = new Character('"');
            var character = new Range(Convert.ToChar(0x20), Convert.ToChar(0xFFFF));
            var characters = new OneOrMore(character);
            var escapeSymbol = new Character('\\');
            var escapeCharacters = new Any("\"\\/bfnrt");
            var escapeValue = new Optional(new Sequence(escapeSymbol, escapeCharacters));
            var escapeHexCharacters = new Character('u');
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexValue = new Optional(new Sequence(escapeSymbol, escapeHexCharacters, hex, hex, hex, hex));

            pattern = new Sequence(quote, characters, escapeValue, hexValue, quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
