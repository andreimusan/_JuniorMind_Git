using System;
using System.Collections.Generic;
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

        [Fact]
        public void TestYield()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            var testedKey = false;
            var testedValue = false;

            foreach (var elem in dictionary)
            {
                if (elem.Key == 10)
                {
                    testedKey = true;
                }

                if (elem.Value == "e")
                {
                    testedValue = true;
                }
            }

            Assert.Equal(5, dictionary.Count);
            Assert.True(testedKey);
            Assert.True(testedValue);
        }

        [Fact]
        public void TestCopyTo()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary.Add(20, "f");

            var array = new KeyValuePair<int, string>[8];

            dictionary.CopyTo(array, 2);

            Assert.Equal(8, array.Length);
            Assert.Equal(dictionary[1], array[2].Value);
        }

        [Fact]
        public void TestContainsValue()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            Assert.Equal(5, dictionary.Count);
            Assert.True(dictionary.ContainsValue("d"));
            Assert.False(dictionary.ContainsValue("z"));
        }

        [Fact]
        public void TestContains()
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
            Assert.Contains(new KeyValuePair<int, string>(10, "c"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(17, "f"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "z"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(7, "d"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(1, "a"), dictionary);
        }

        [Fact]
        public void TestIndexerGetArgumentNullException()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("a", "a");
            dictionary.Add("b", "b");
            dictionary.Add("c", "c");
            dictionary.Add("d", "d");
            dictionary.Add("e", "e");

            var exception = Assert.Throws<ArgumentNullException>(() => dictionary[null]);
            Assert.Equal("Key is null.", exception.Message);
        }

        [Fact]
        public void TestIndexerGetKeyNotFoundException()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            var exception = Assert.Throws<KeyNotFoundException>(() => dictionary[100]);
            Assert.Equal("Key is not found.", exception.Message);
        }

        [Fact]
        public void TestIndexerSetArgumentNullException()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("a", "a");
            dictionary.Add("b", "b");
            dictionary.Add("c", "c");
            dictionary.Add("d", "d");
            dictionary.Add("e", "e");

            var exception = Assert.Throws<ArgumentNullException>(() => dictionary[null] = "f");
            Assert.Equal("Key is null.", exception.Message);
        }

        [Fact]
        public void TestIndexerSetKeyNotFoundException()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            var exception = Assert.Throws<KeyNotFoundException>(() => dictionary[100] = "f");
            Assert.Equal("Key is not found.", exception.Message);
            Assert.Equal("f", dictionary[100]);
        }

        [Fact]
        public void TestAddArgumentNullException()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("a", "a");
            dictionary.Add("b", "b");

            var exception = Assert.Throws<ArgumentNullException>(() => dictionary.Add(null, "c"));
            Assert.Equal("Key is null.", exception.Message);
        }

        [Fact]
        public void TestAddArgumentExceptionForExistingKey()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            var exception = Assert.Throws<ArgumentException>(() => dictionary.Add(10, "z"));
            Assert.Equal("An element with the same key already exists.", exception.Message);
        }

        [Fact]
        public void TestContainsArgumentNullException()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("a", "a");
            dictionary.Add("b", "b");

            var exception = Assert.Throws<ArgumentNullException>(() => dictionary.ContainsKey(null));
            Assert.Equal("Key is null.", exception.Message);
        }

        [Fact]
        public void TestRemoveArgumentNullException()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("a", "a");
            dictionary.Add("b", "b");

            var exception = Assert.Throws<ArgumentNullException>(() => dictionary.Remove(null));
            Assert.Equal("Key is null.", exception.Message);
        }
    }
}
