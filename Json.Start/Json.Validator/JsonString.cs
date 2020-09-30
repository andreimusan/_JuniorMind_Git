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

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool HasDoubleQuotes(string input)
        {
            return input.Length > 1 && input[0] == '"' && input[^1] == '"';
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
                if (input[i] == '\\' && !IsEscapeSymbols(input, i))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsEscapeSymbols(string input, int position)
        {
            const string escapeSymbols = "\"\\/bfnrt";
            const int minHexUnits = 4;

            if (input[position + 1] == 'u' && input.Length - 1 - (position + 1) > minHexUnits)
            {
                return IsHexValue(input, position + 1, minHexUnits);
            }

            return position + 1 != input.Length - 1 && escapeSymbols.Contains(input[position + 1]) || input[position - 1] == '\\';
        }

        static bool IsHexValue(string input, int min, int max)
        {
            for (int i = min + 1; i <= max; i++)
            {
                if (!IsHexChar(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsHexChar(char c)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }

            return !(c >= 'a' && c <= 'f') || !(c >= 'A' && c <= 'F');
        }
    }
}
