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

        public int CountVowels()
        {
            return text.ToLower().Count(c => "aeiou".Contains(c));
        }

        public int CountConsonants()
        {
            return text.ToLower().Count(char.IsLetter) - CountVowels();
        }

        public char FirstUniqueCharacter()
        {
            return text.GroupBy(c => c).First(g => g.Count() == 1).Key;
        }

        public char CharacterMostUsed()
        {
            return text.GroupBy(c => c).OrderBy(g => g.Count()).Last().Key;
        }

        public IEnumerable GenerateTextSubstringPalindrome()
        {
            var result = from i in Enumerable.Range(1, text.Length)
                         from j in Enumerable.Range(0, text.Length - i + 1)
                         let substring = text.Substring(j, i)
                         where substring.SequenceEqual(substring.Reverse())
                         select substring;

            return result;
        }
    }
}
