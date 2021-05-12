using System;
using Xunit;

namespace Arrays.Facts
{
    public class DictionaryFacts
    {
        [Fact]
        public void TestAddLastElement()
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

        [Fact]
        public void TestClear()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary.Clear();
            dictionary.Add(10, "z");

            Assert.Equal(1, dictionary.Count);
            Assert.Equal("z", dictionary[10]);
        }

        [Fact]
        public void TestContainsKey()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            Assert.Equal(5, dictionary.Count);
            Assert.True(dictionary.ContainsKey(10));
            Assert.False(dictionary.ContainsKey(100));
        }

        [Fact]
        public void TestRemoveMiddleElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary.Remove(10);

            Assert.Equal(4, dictionary.Count);
            Assert.False(dictionary.ContainsKey(10));
        }

        [Fact]
        public void TestRemoveLastElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary.Remove(12);

            Assert.Equal(4, dictionary.Count);
            Assert.False(dictionary.ContainsKey(12));
        }

        [Fact]
        public void TestAddMiddleElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary.Remove(7);
            dictionary.Remove(1);

            dictionary.Add(17, "f");
            dictionary.Add(3, "g");

            Assert.Equal(5, dictionary.Count);
            Assert.False(dictionary.ContainsKey(7));
            Assert.False(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(17));
            Assert.True(dictionary.ContainsKey(3));
        }

        [Fact]
        public void TestKeys()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary.Remove(7);
            dictionary.Remove(1);

            dictionary.Add(17, "f");
            dictionary.Add(3, "g");

            var keys = dictionary.Keys;

            Assert.Equal(5, keys.Count);
            Assert.False(keys.Contains(7));
            Assert.False(keys.Contains(1));
            Assert.True(keys.Contains(17));
            Assert.True(keys.Contains(3));
        }

        [Fact]
        public void TestValues()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            dictionary.Remove(7);
            dictionary.Remove(1);

            dictionary.Add(17, "f");
            dictionary.Add(3, "g");

            var values = dictionary.Values;

            Assert.Equal(5, values.Count);
            Assert.False(values.Contains("d"));
            Assert.False(values.Contains("a"));
            Assert.True(values.Contains("f"));
            Assert.True(values.Contains("g"));
        }
    }
}
