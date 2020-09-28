using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (input is null)
            {
                return false;
            }

            return IsWrappedInDoubleQuotes(input);
        }

        static bool IsWrappedInDoubleQuotes(string input)
        {
            return input.Length > 1 + 1 && input[0] == '"' && input[^1] == '"';
        }
    }
}
