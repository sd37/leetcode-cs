namespace test
{
    using dev;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class TestMaximumSubarrayAverageII : IDisposable
    {
        public static class TestData
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[] { new int[] { 1,12,-5,-6,50,3 }, 4 , 12.75};
                yield return new object[] { new int[] {8,9,3,1,8,3,0,6,9,2}, 8, 5.22222};
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GenerateTestData), MemberType = typeof(TestData))]
        public void TestSolution(int[] input, int k, double expectedResult)
        {
            var soln = new MaxiumumSubarrayAverageII();
            var result = soln.FindMaxAverage(input, k);

            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
        }
    }
}