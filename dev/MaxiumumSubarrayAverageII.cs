// https://leetcode.com/problems/maximum-average-subarray-ii/solution/
// Status = TLE (59/74) pass
// You are given an integer array nums consisting of n elements, and an integer k.
//
// Find a contiguous subarray whose length is greater than or equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.
// Input: nums = [1,12,-5,-6,50,3], k = 4
// Output: 12.75000
// Explanation:
// - When the length is 4, averages are [0.5, 12.75, 10.5] and the maximum average is 12.75
// - When the length is 5, averages are [10.4, 10.8] and the maximum average is 10.8
// - When the length is 6, averages are [9.16667] and the maximum average is 9.16667
// The maximum average is when we choose a subarray of length 4 (i.e., the sub array [12, -5, -6, 50]) which has the max average 12.75, so we return 12.75
// Note that we do not consider the subarrays of length < 4.


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