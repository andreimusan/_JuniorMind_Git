using System;

namespace RangeProblem
{
    public class Character : IPattern
    {
        private readonly char character;

        public Character(char character)
        {
            this.character = character;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] == character
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);
        }
    }
}
