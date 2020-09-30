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
            if (input[^1] == '.')
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '.' || CountDots(input) > 1)
                {
                    return false;
                }
            }

            return true;
        }

        static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        static bool StartsWithMinus(string input)
        {
            return input.Length > 1 && input[0] == '-';
        }

        static int CountDots(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == '.')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
