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
            
            Assert.Equal(11, sentence.CountVowels());
            Assert.Equal(15, sentence.CountConsonants());
        }

        [Fact]
        public void TestFirstUniqueCharacter()
        {
            var sentence = new StringOperations("enter a sentence or a character?!");
            
            Assert.Equal('s', sentence.FirstUniqueCharacter());
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
