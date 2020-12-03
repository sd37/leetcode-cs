using System;
/*
 * @lc app=leetcode id=746 lang=csharp
 *
 * [746] Min Cost Climbing Stairs
 *
 * https://leetcode.com/problems/min-cost-climbing-stairs/description/
 *
 * algorithms
 * Easy (50.72%)
 * Likes:    2580
 * Dislikes: 561
 * Total Accepted:    195.2K
 * Total Submissions: 384.8K
 * Testcase Example:  '[0,0,0,0]'
 *
 * 
 * On a staircase, the i-th step has some non-negative cost cost[i] assigned (0
 * indexed).
 * 
 * Once you pay the cost, you can either climb one or two steps. You need to
 * find minimum cost to reach the top of the floor, and you can either start
 * from the step with index 0, or the step with index 1.
 * 
 * 
 * Example 1:
 * 
 * Input: cost = [10, 15, 20]
 * Output: 15
 * Explanation: Cheapest is start on cost[1], pay that cost and go to the
 * top.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
 * Output: 6
 * Explanation: Cheapest is start on cost[0], and only step on 1s, skipping
 * cost[3].
 * 
 * 
 * 
 * Note:
 * 
 * cost will have a length in the range [2, 1000].
 * Every cost[i] will be an integer in the range [0, 999].
 * 
 * 
 */

// Status = AC
namespace dev
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class MinCostClimbStairsProblem
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            if(cost.Length == 0)
            {
                return 0;
            }

            if(cost.Length == 1)
            {
                return cost[0];
            }

            var startp0 = cost[0..];
            var startp1 = cost[1..];
            var cachep0 = new int[startp0.Length + 1];
            var cachep1 = new int[startp1.Length + 1];

            var minCostStartP0 = this.MinCostHelper(startp0, cachep0);
            var minCostStartP1 = this.MinCostHelper(startp1, cachep1);

            return Math.Min(minCostStartP0, minCostStartP1);
        }

        private int MinCostHelper(int[] cost, int[] solnCache)
        {
            solnCache[0] = 0;
            solnCache[1] = cost[0];
            solnCache[2] = cost[0];

            for (var i = 3; i <= cost.Length; i++)
            {
                var step1Cost = solnCache[i - 1] + cost[i - 1];
                var step2Cost = solnCache[i - 2] + cost[i - 2];

                solnCache[i] = Math.Min(step1Cost, step2Cost);
            }

            return solnCache.Last();
        }
    }
}
