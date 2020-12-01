/*
You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

You may assume that you have an infinite number of each kind of coin.

Status = AC
https://leetcode.com/problems/coin-change/
*/
namespace dev
{
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Collections.Generic;
    using System;

    public class CoinChangeProblem
    {
        private Dictionary<int, int> coinSolns = new Dictionary<int, int>();

        public int CoinChange(int[] coins, int amount)
        {
            var result = CoinChangeHelper(new HashSet<int>(coins), amount);
            return result;
        }

        public int CoinChangeHelper(HashSet<int> coins, int amount)
        {
            if(amount < 0)
            {
                return -1;
            }

            if(amount == 0 || coins.Count == 0)
            {
                return coinSolns[0] = 0;
            }

            if(coins.Contains(amount))
            {
                return coinSolns[amount] = 1;
            }

            if(!coinSolns.ContainsKey(amount))
            {
                coinSolns[amount] = 0;
                int minChange = int.MaxValue;

                foreach (var coin in coins)
                {
                    var res = CoinChangeHelper(coins, amount - coin);
                    if(res >=0)
                    {
                        minChange = Math.Min(minChange, res);
                    }
                }

                if(minChange == int.MaxValue)
                {
                    coinSolns[amount] = -1;
                }
                else
                {
                    coinSolns[amount] = 1 + minChange;
                }
            }

            return coinSolns[amount];
        }
    }
}