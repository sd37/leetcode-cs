namespace test
{
    using System;
    using System.Collections.Generic;
    using dev;
    using Xunit;

    public class TestMinCostClimbingStairs : IDisposable
    {
        public static class TestData
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[] { new int[] { 10, 15, 20 }, 15 };
                yield return new object[] { new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1}, 6 };
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GenerateTestData), MemberType = typeof(TestData))]
        public void TestSolution(int[] costs, int expectedResult)
        {
            var soln = new MinCostClimbStairsProblem();
            var result = soln.MinCostClimbingStairs(costs);
            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
        }
    }
}