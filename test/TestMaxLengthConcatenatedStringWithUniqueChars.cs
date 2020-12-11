namespace test
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using dev;
    using Xunit;

    public class TestMaxLengthContenatedStringWithUniqueChars : IDisposable
    {
        public static class TestData
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[] { new string[] { "un","iq","ue"}, 4};
                yield return new object[] { new string[] { "cha","r","act","ers" }, 6 };
                yield return new object[] { new string[] { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p" }, 16 };
                yield return new object[] { new string[] { "a","b" }, 2 };
                yield return new object[] { new string[] { "aa","bbb" }, 0 };
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GenerateTestData), MemberType = typeof(TestData))]
        public void TestSolution(string[] arr, int expectedResult)
        {
            var soln = new MaxLengthConcatenateStringWithUniqueCharacters();
            var result = soln.MaxLength(arr.ToList());
            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
        }
    }
}