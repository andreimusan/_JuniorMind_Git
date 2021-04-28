using System;
using Xunit;

namespace Arrays.Facts
{
    public class DictionaryFacts
    {
        [Fact]
        public void TestAdd()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            Assert.Equal(5, dictionary.Count);
        }

        [Fact]
        public void TestGetValue()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            Assert.Equal(5, dictionary.Count);
            Assert.Equal("c", dictionary[10]);
        }

        [Fact]
        public void TestSetValue()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary[10] = "z";

            Assert.Equal(5, dictionary.Count);
            Assert.Equal("z", dictionary[10]);
        }
    }
}
