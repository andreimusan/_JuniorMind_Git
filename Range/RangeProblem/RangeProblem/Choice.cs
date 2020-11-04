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
                if (pattern.Match(text).Success())
                {
                    return new SuccessMatch(pattern.Match(text).RemainingText());
                }
            }

            return new FailedMatch(text);
        }
    }
}
