namespace test
{
    using System;
    using System.Collections.Generic;
    using dev;
    using Xunit;

    public class TestDivisionGameProblem : IDisposable
    {
        public static class TestData
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[] { 3, false };
                yield return new object[] { 2, true };
                yield return new object[] { 4, true };
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GenerateTestData), MemberType = typeof(TestData))]
        public void TestSolution(int N, bool expectedResult)
        {
            var soln = new DivisorGameProblem();
            var result = soln.DivisorGame(N);
            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
        }
    }
}