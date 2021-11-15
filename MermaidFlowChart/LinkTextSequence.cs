using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class LinkTextSequence : IPattern
    {
        private readonly IPattern pattern;
        private string cutText = "";

        public LinkTextSequence()
        {
            var line = new Character('-');
            var arrow = new Character('>');
            var dot = new Character('.');
            var equal = new Character('=');

            var openLink = new Sequence(line, line, line);
            var linkWithArrowHead = new Sequence(line, line, arrow);

            var dottedLink = new Sequence(line, dot, line);
            var dottedLinkWithArrowHead = new Sequence(line, dot, line, arrow);
            var dottedLinkWithArrowHeadAndText = new Sequence(dot, line, arrow);

            var thickLink = new Sequence(equal, equal, equal);
            var thickLinkWithArrowHead = new Sequence(equal, equal, arrow);

            var shapeCharacter = new Choice(
                        new Character(' '),
                        new Character('!'),
                        new Range('#', '\''),
                        new Range('*', ','),
                        new Range('.', '/'),
                        new Range('0', '9'),
                        new Character(':'),
                        new Range('<', '?'),
                        new Range('A', 'Z'),
                        new Character('\\'),
                        new Range('^', '`'),
                        new Range('a', 'z'));
            var shapeText = new Many(shapeCharacter);

            var shapeCharacterWithoutDot = new Choice(
                        new Character(' '),
                        new Character('!'),
                        new Range('#', '\''),
                        new Range('*', ','),
                        new Character('/'),
                        new Range('0', '9'),
                        new Character(':'),
                        new Range('<', '?'),
                        new Range('A', 'Z'),
                        new Character('\\'),
                        new Range('^', '`'),
                        new Range('a', 'z'));
            var shapeTextWithoutDot = new Many(shapeCharacterWithoutDot);

            var shapeCharacterWithoutEqual = new Choice(
                        new Character(' '),
                        new Character('!'),
                        new Range('#', '\''),
                        new Range('*', ','),
                        new Range('.', '/'),
                        new Range('0', '9'),
                        new Character(':'),
                        new Character('<'),
                        new Range('>', '?'),
                        new Range('A', 'Z'),
                        new Character('\\'),
                        new Range('^', '`'),
                        new Range('a', 'z'));
            var shapeTextWithoutEqual = new Many(shapeCharacterWithoutEqual);

            var textDelimiter = new Character('|');
            var whitespace = new Many(new Any(" \r\n\t"));

            pattern = new Choice(
                new Sequence(line, line, whitespace, shapeText, whitespace, openLink),
                new Sequence(openLink, whitespace, textDelimiter, shapeText, textDelimiter),
                new Sequence(openLink),
                new Sequence(line, line, whitespace, shapeText, whitespace, linkWithArrowHead),
                new Sequence(linkWithArrowHead, whitespace, textDelimiter, shapeText, textDelimiter),
                new Sequence(linkWithArrowHead),
                new Sequence(line, dot, whitespace, shapeTextWithoutDot, whitespace, dottedLinkWithArrowHeadAndText),
                new Sequence(dottedLinkWithArrowHead, whitespace, textDelimiter, shapeText, textDelimiter),
                new Sequence(dottedLinkWithArrowHead),
                new Sequence(line, dot, whitespace, shapeTextWithoutDot, whitespace, dot, line),
                new Sequence(dottedLink, whitespace, textDelimiter, shapeText, textDelimiter),
                new Sequence(dottedLink),
                new Sequence(equal, equal, whitespace, shapeTextWithoutEqual, whitespace, thickLinkWithArrowHead),
                new Sequence(thickLinkWithArrowHead, whitespace, textDelimiter, shapeText, textDelimiter),
                new Sequence(thickLinkWithArrowHead),
                new Sequence(equal, equal, whitespace, shapeTextWithoutEqual, whitespace, thickLink),
                new Sequence(thickLink, whitespace, textDelimiter, shapeText, textDelimiter),
                new Sequence(thickLink));
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
