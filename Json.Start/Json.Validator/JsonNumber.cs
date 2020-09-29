using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return HasContent(input)
                && IsFormedFromDigits(input)
                && !StartsWithZero(input);
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool IsFormedFromDigits(string input)
        {
            if (StartsWithMinus(input))
            {
                input = input.Remove(0, 1);
            }

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }

        static bool StartsWithZero(string input)
        {
            if (StartsWithMinus(input))
            {
                input = input.Remove(0, 1);
            }

            return input.Length > 1 && input[0] == '0';
        }

        static bool StartsWithMinus(string input)
        {
            return input.Length > 1 && input[0] == '-';
        }

        static bool IsFractional(string input)
        {
            foreach (char c in input)
            {
                if (c == '.')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
