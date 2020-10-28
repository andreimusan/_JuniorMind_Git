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
            return new Match(!string.IsNullOrEmpty(text) && text[0] == character);
        }
    }
}
