using LinqExercitii;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace LinqExeritii.Facts
{
    public class StringOperationsFacts
    {
        [Fact]
        public void TestVowelsAndConsonantsCount()
        {
            var sentence = new StringOperations("Enter a Sentence or a Character?!");
            var lettersCount = sentence.CountVowelsAndConsonants();

            Assert.Equal(11, lettersCount.vowels);
            Assert.Equal(15, lettersCount.consonants);
        }

        [Fact]
        public void TestFirstUniqueCharacter()
        {
            var sentence = new StringOperations("enter a sentence or a character?!");
            
            Assert.Equal('s', sentence.FirstUniqueCharacter());
        }

        [Fact]
        public void TestConvertStringToInt()
        {
            var sentence = new StringOperations("-1234");

            Assert.Equal(-1234, sentence.ConvertStringToInt());
        }

        [Fact]
        public void TestCharacterMostUsed()
        {
            var sentence = new StringOperations("enter a sentence or a character?!");

            Assert.Equal('e', sentence.CharacterMostUsed());
        }

        [Fact]
        public void TestGenerateTextSubstringPalindrome()
        {
            var sentence = new StringOperations("aabaac");
            var result = sentence.GenerateTextSubstringPalindrome().Cast<string>().ToList();
            var options = new List<string>(){"a", "a", "b", "a", "a", "c", "aa", "aa", "aba", "aabaa" };

            Assert.True(result.SequenceEqual(options));
        }
    }
}
