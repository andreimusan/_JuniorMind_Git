using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input)
                && IsWrappedInDoubleQuotes(input);
        }

        static bool IsWrappedInDoubleQuotes(string input)
        {
            return input.Length > 1 + 1 && input[0] == '"' && input[^1] == '"';
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
