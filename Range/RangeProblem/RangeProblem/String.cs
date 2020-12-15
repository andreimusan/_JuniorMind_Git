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

            var escapeSeq = new Sequence(
                                new Character('\\'),
                                new Any("\"\\/bfnrt"));

            var hex = new Choice(
                        new Range('0', '9'),
                        new Range('a', 'f'),
                        new Range('A', 'F'));

            var hexSeq = new Sequence(
                            new Character('\\'),
                            new Character('u'),
                            new Sequence(hex, hex, hex, hex));

            var character = new Choice(
                                new Range(Convert.ToChar(0x20), Convert.ToChar(0xFFFF), "\"\\"),
                                escapeSeq,
                                hexSeq);

            var characters = new Many(character);

            pattern = new Sequence(quote, characters, quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
