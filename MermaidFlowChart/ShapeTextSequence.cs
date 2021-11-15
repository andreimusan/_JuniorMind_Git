using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class ShapeTextSequence : IPattern
    {
        private readonly IPattern pattern;
        private string cutText = "";

        public ShapeTextSequence()
        {
            var id = new Choice(
                        new Character('!'),
                        new Range('#', '$'),
                        new Range('&', '\''),
                        new Range('*', '/'),
                        new Range('0', '9'),
                        new Character(':'),
                        new Character('='),
                        new Character('?'),
                        new Range('A', 'Z'),
                        new Character('\\'),
                        new Range('_', '`'),
                        new Range('a', 'z'));

            var shapeId = new OneOrMore(id);

            var shapeOpen = new Choice(
                        new Sequence(new Character('['), new Character('[')),
                        new Sequence(new Character('['), new Character('(')),
                        new Sequence(new Character('['), new Character('/')),
                        new Sequence(new Character('['), new Character('\\')),
                        new Sequence(new Character('('), new Character('[')),
                        new Sequence(new Character('('), new Character('(')),
                        new Sequence(new Character('{'), new Character('{')),
                        new Character('['),
                        new Character('('),
                        new Character('{'),
                        new Character('>'));

            var shapeClose = new Choice(
                        new Sequence(new Character(']'), new Character(']')),
                        new Sequence(new Character(')'), new Character(']')),
                        new Sequence(new Character('/'), new Character(']')),
                        new Sequence(new Character('\\'), new Character(']')),
                        new Sequence(new Character(']'), new Character(')')),
                        new Sequence(new Character(')'), new Character(')')),
                        new Sequence(new Character('}'), new Character('}')),
                        new Character(']'),
                        new Character(')'),
                        new Character('}'));

            var shapeCharacter = new Choice(
                        new Character(' '),
                        new Character('!'),
                        new Range('#', '\''),
                        new Range('*', '/'),
                        new Range('0', '9'),
                        new Character(':'),
                        new Range('<', '?'),
                        new Range('A', 'Z'),
                        new Character('\\'),
                        new Range('^', '`'),
                        new Range('a', 'z'));

            var shapeText = new Many(shapeCharacter);

            var escapeCharacter = new Character('\"');
            var shapeTextEscape = new Many(
                                    new Choice(
                                        new Range(' ', '!'),
                                        new Range('#', '~')));

            var whitespace = new Many(new Any(" \r\n\t"));

            pattern = new Choice(
                        new Sequence(whitespace, shapeId, shapeOpen, escapeCharacter, shapeTextEscape, escapeCharacter, shapeClose, whitespace),
                        new Sequence(whitespace, shapeId, shapeOpen, shapeText, shapeClose, whitespace));
        }

        public IMatch Match(string text)
        {
            cutText += pattern.CutText();
            return pattern.Match(text);
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
