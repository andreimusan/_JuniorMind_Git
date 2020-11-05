﻿namespace RangeProblem
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);

                if (match.Success())
                {
                    return new SuccessMatch(match.RemainingText());
                }
            }

            return new FailedMatch(text);
        }
    }
}
