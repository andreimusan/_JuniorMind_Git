using System;

namespace RangeProblem
{
    public class Character
    {
        private readonly char character;

        public Character(char character)
        {
            this.character = character;
        }

        public bool Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] == character;
        }
    }
}
