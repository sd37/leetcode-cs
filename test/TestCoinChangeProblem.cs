namespace test
{
    using System;
    using System.Collections.Generic;
    using dev;
    using Xunit;

    public class TestCoinChangeProblem : IDisposable
    {
        public static class TestData
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[] { new int[] { 1,2,5 }, 11 , 3};
                yield return new object[] { new int[] { 2 }, 3 , -1};
                yield return new object[] { new int[] { 1 }, 1 , 1};
                yield return new object[] { new int[] { 1 }, 2 , 2};
                yield return new object[] { new int[] { 1 }, 0 , 0};
                yield return new object[] { new int[] { 186,419,83,408 }, 6249, 20};
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GenerateTestData), MemberType = typeof(TestData))]
        public void TestSolution(int[] coins, int amount, int expectedResult)
        {
            var soln = new CoinChangeProblem();
            var result = soln.CoinChange(coins, amount);
            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
        }
    }
}