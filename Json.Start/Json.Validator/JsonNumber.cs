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

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]) && !CheckExponent(input, i) && input[i] != '.' || !CountElement(input))
                {
                    return false;
                }
            }

            return CheckExponentIndex(input);
        }

        static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        static bool StartsWithMinus(string input)
        {
            return input.Length > 1 && input[0] == '-';
        }

        static bool CountElement(string input)
        {
            int countDots = 0;
            int countExponent = 0;

            foreach (char c in input)
            {
                if (c == '.')
                {
                    countDots++;
                }

                if (c == 'e' || c == 'E')
                {
                    countExponent++;
                }
            }

            return countDots <= 1 && countExponent <= 1;
        }

        static bool CheckExponent(string input, int index)
        {
            if (index == input.Length - 1)
            {
                return false;
            }

            return input[index] == 'e' || input[index] == 'E' || input[index] == '+' || input[index] == '-';
        }

        static bool CheckExponentIndex(string input)
        {
            input = input.ToLower();

            return input.IndexOf('.') < 0 || input.IndexOf('e') < 0 || input.IndexOf('.') <= input.IndexOf('e');
        }
    }
}
