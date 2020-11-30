// https://leetcode.com/problems/maximum-average-subarray-ii/solution/
// Status = TLE (59/74) pass
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
            double maxAvg = double.MinValue;

            for (var i = 0; i < nums.Length; i++)
            {
                avgMatK[1].Add(nums[i]);
                if(1 >= k)
                {
                    maxAvg = Math.Max(nums[i], maxAvg);
                }
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
                    if(i >= k)
                    {
                        maxAvg = Math.Max(newAvg, maxAvg);
                    }
                }
            }

            return Math.Round(maxAvg, 5);
        }
    }
}