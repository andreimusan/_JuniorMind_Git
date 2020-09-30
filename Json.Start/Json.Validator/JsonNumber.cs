using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (HasContent(input) && StartsWithMinus(input))
            {
                input = input.Remove(0, 1);
            }

            return HasContent(input)
                && IsRealNumber(input)
                && !StartsWithZero(input);
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool IsRealNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    return true;
                }
            }

            return false;
        }

        static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        static bool StartsWithMinus(string input)
        {
            return input.Length > 1 && input[0] == '-';
        }
    }
}
