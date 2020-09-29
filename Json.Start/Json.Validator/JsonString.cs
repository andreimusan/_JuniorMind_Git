using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input)
                && HasDoubleQuotes(input)
                && IsJsonCharacter(input);
        }

        static bool HasDoubleQuotes(string input)
        {
            return input.Length > 1 && input[0] == '"' && input[^1] == '"';
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool IsJsonCharacter(string input)
        {
            return ContainsLargeUnicodeCharacters(input)
                && !ContainsControlCharacters(input);
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
            const int min = 0x20;
            const int max = 0xFFFF;

            foreach (char c in input)
            {
                if (Convert.ToInt32(c) >= min && Convert.ToInt32(c) <= max)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CompareHexValues(char c)
        {
            const int min = 0x20;
            const int max = 0xFFFF;
            int charHexValue = Convert.ToInt32(c);

            return Convert.ToInt32(c) >= min && Convert.ToInt32(c) <= max;
        }
    }
}
