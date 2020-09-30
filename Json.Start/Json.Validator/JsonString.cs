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
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] == '\\')
                {
                    return CheckEscapeSymbols(input, i);
                }
            }

            return true;
        }

        static bool CheckEscapeSymbols(string input, int position)
        {
            if (position + 1 == input.Length - 1)
            {
                return false;
            }

            const string escapeSymbols = "\"\\/bfnrt";
            const int minHexUnits = 4;

            if (input[position + 1] == 'u' && input.Length - 1 - (position + 1) > minHexUnits)
            {
                return IsHexValue(input, position + 1, minHexUnits);
            }

            return escapeSymbols.Contains(input[position + 1]);
        }

        static bool IsHexValue(string input, int min, int max)
        {
            for (int i = min + 1; i <= max; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
                else if (!(input[i] >= 'a' && input[i] <= 'f') || !(input[i] >= 'A' && input[i] <= 'F'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
