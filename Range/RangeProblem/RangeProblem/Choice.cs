namespace RangeProblem
{
    public class Choice : IPattern
    {
        private readonly IPattern character;
        private readonly IPattern range;

        public Choice(params IPattern[] patterns)
        {
            this.character = patterns[0];
            this.range = patterns[1];
        }

        public bool Match(string text)
        {
            return character.Match(text) || range.Match(text);
        }
    }
}
