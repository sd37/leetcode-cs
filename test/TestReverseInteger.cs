namespace test
{
    using dev;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class TestReverseInteger : IDisposable
    {
        public static class TestData
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[] {123, 321};
                yield return new object[] {-123, -321};
                yield return new object[] {120, 21};
                yield return new object[] {0, 0};
                yield return new object[] {int.MaxValue, 0};
                yield return new object[] {-2147483648, 0};
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GenerateTestData), MemberType = typeof(TestData))]
        public void TestSolution(int input, int expectedResult)
        {
            var soln = new ReverseInteger();
            var result = soln.Reverse(input);

            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
        }
    }
}