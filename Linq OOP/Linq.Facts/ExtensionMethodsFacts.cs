using System;
using Xunit;

namespace Linq.Facts
{
    public class ExtensionMethodsFacts
    {
        [Fact]
        public void TestAll()
        {
            var array = new int[] { 2, 4, 6, 8 };
            bool isEven = array.All(n => n % 2 == 0);
            bool isGreaterThanFive = array.All(n => n > 5);
            string exceptionArray = null;

            Assert.True(isEven);
            Assert.False(isGreaterThanFive);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.All(c => c > 'a'));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => array.All(null));
            Assert.Equal("Predicate is null.", exception.Message);
        }

        [Fact]
        public void TestAny()
        {
            var array = new char[] { 'b', 'd', 'x', 'y' };
            bool isBetweenAAndC = array.Any(c => c > 'a' && c < 'c');
            bool isGreaterThanZ = array.Any(c => c > 'z');
            string exceptionArray = null;

            Assert.True(isBetweenAAndC);
            Assert.False(isGreaterThanZ);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Any(c => c > 'a'));
            Assert.Equal("Source is null.", exception.Message);
        }
    }
}
