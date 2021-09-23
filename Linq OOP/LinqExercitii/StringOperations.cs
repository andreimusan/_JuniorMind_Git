using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public class StringOperations
    {
        private readonly string text;

        public StringOperations(string text)
        {
            this.text = text;
        }

        public (int vowels, int consonants) CountVowelsAndConsonants()
        {
            var lettersCount = (vowels: 0, consonants: 0);

            var letterGroup = text.ToLower().Where(c => char.IsLetter(c)).GroupBy(l => "aeiou".Contains(l), (key, letter) => new { Key = key, Count = letter.Count() }).ToList();

            lettersCount.vowels = letterGroup[0].Count;
            lettersCount.consonants = letterGroup[1].Count;

            return lettersCount;
        }

        public char FirstUniqueCharacter()
        {
            return text.GroupBy(c => c).First(g => g.Count() == 1).Key;
        }

        public int ConvertStringToInt()
        {
            const int ten = 10;
            int sign = 1;
            string textValue = text;

            if (text[0] == '-')
            {
                sign = -1;
                textValue = text.Substring(1);
            }

            if (textValue == "" || textValue.Any(c => !char.IsDigit(c)))
            {
                throw new FormatException("The string is not a number");
            }

            var numberResult = textValue.Aggregate(0, (number, ch) => number * ten + (ch - '0'));

            return numberResult * sign;
        }

        public char CharacterMostUsed()
        {
            return text.GroupBy(c => c).Aggregate((elem, max) => elem.Count() > max.Count() ? elem : max).Key;
        }

        public IEnumerable<string> GenerateTextSubstringPalindrome()
        {
            var result = Enumerable.Range(1, text.Length).
                SelectMany(i => Enumerable.Range(0, text.Length - i + 1), (i, j) => text.Substring(j, i)).
                Where(s => s.SequenceEqual(s.Reverse())).
                Select(s => s);

            return result;
        }
    }
}
