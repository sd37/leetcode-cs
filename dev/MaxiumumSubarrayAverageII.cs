using System.Text.RegularExpressions;
namespace dev
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MaxiumumSubarrayAverageII
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            if(k <= 0 || nums.Length == 0)
            {
                return 0.0;
            }

            if(nums.Length == 1)
            {
                return nums[0];
            }

            var avgMatK = new Dictionary<int, List<Double>>();
            avgMatK[1] = new List<double>();

            for (var i = 0; i < nums.Length; i++)
            {
                avgMatK[1].Add(nums[i]);
            }

            for (var i = 2; i <= nums.Length; i++)
            {
                avgMatK[i] = new List<double>();
                var prevAvgs = avgMatK[i - 1];
                for (var j = 0; j < prevAvgs.Count - 1; j++)
                {
                    int numOfElements = i - 1;
                    double prevSum = prevAvgs[j] * numOfElements;
                    double newAvg = (prevSum + nums[j + numOfElements]) / i;
                    avgMatK[i].Add(newAvg);
                }
            }

            return Math.Round(avgMatK.Where(x => x.Key >= k).Max(x => x.Value.Max()), 5);
        }
    }
}