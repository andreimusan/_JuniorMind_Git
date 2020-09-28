using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input)
                && HasDoubleQuotes(input)
                && HasSimpleQuotes(input)
                && !ContainsControlCharacters(input);
        }

        static bool HasDoubleQuotes(string input)
        {
            return input.Length >= 1 && input[0] == '"' && input[^1] == '"';
        }

        static bool HasSimpleQuotes(string input)
        {
            return input.Length >= 1 && input[0] == '\'' && input[^1] == '\'';
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool ContainsControlCharacters(string input)
        {
            foreach (char c in input)
            {
                if (char.IsControl(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
