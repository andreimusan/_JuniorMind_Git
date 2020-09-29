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
                && !ContainsControlCharacters(input)
                && CheckEscapeCharacter(input);
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

        static bool CheckEscapeCharacter(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\')
                {
                    return CheckCharacterFollowingEscapeCharacter(input, i);
                }
            }

            return true;
        }

        static bool CheckCharacterFollowingEscapeCharacter(string input, int position)
        {
            char[] escapeSymbols = { '\'', '"', '\\', '0', 'a', 'b', 'f', 'n', 'r', 't', 'v', 'u' };

            if (position < input.Length)
            {
                return false;
            }

            for (int i = 0; i < escapeSymbols.Length; i++)
            {
                if (input[position + 1] != escapeSymbols[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
