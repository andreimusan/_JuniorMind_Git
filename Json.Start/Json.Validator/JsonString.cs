using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input)
                && HasQuotes(input)
                && !ContainsControlCharacters(input)
                && ContainsLargeUnicodeCharacters(input);
        }

        static bool HasQuotes(string input)
        {
            return HasDoubleQuotes(input)
                && HasSimpleQuotes(input);
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
                    return true;
                }
            }

            return false;
        }

        static bool ContainsLargeUnicodeCharacters(string input)
        {
            foreach (char c in input)
            {
                if (CompareHexValues(c))
                {
                    return true;
                }
            }

            return false;
        }

        static bool CompareHexValues(char c)
        {
            int min = Convert.ToInt32("0020", 16);
            int max = Convert.ToInt32("10FFFF", 16);
            int charHexValue = Convert.ToInt32(c.ToString(), 16);

            return charHexValue >= min && charHexValue <= max;
        }
    }
}
