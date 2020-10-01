using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
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
                if (!char.IsDigit(input[i]) && input[i] != '.' && !CheckExponent(input, i) && !HasPositiveAndNegative(input, i))
                {
                    return false;
                }
            }

            return CountElement(input)
                && CheckExponentIndex(input);
        }

        static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        static bool CountElement(string input)
        {
            int countDots = 0;
            int countExponent = 0;
            int countOperator = 0;

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

                if (c == '-' || c == '+')
                {
                    countOperator++;
                }
            }

            return countDots <= 1 && countExponent <= 1 && countOperator <= 1 + 1;
        }

        static bool CheckExponent(string input, int index)
        {
            if (index == 0 || index == input.Length - 1)
            {
                return false;
            }

            input = input.ToLower();

            return input[index] == 'e';
        }

        static bool CheckExponentIndex(string input)
        {
            input = input.ToLower();

            return input.IndexOf('.') < 0 || input.IndexOf('e') < 0 || input.IndexOf('.') <= input.IndexOf('e');
        }

        static bool HasPositiveAndNegative(string input, int index)
        {
            if (index == input.Length - 1)
            {
                return false;
            }

            input = input.ToLower();

            var firstPosition = index == 0 && (input[index] == '-' || input[index] == '+');
            var afterExponent = index > 1 && input[index - 1] == 'e' && (input[index] == '-' || input[index] == '+');

            return firstPosition
                || afterExponent;
        }
    }
}
