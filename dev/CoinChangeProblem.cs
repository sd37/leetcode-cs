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
            if(amount == 0 || coins.Count == 0)
            {
                coinSolns[0] = 0;
                return coinSolns[0];
            }

            if(coins.Contains(amount))
            {
                coinSolns[amount] = 1;
                return coinSolns[amount];
            }

            if(!coinSolns.ContainsKey(amount))
            {
                coinSolns[amount] = 0;
                int minChange = int.MaxValue;

                foreach (var coin in coins)
                {
                    if(amount - coin < 0)
                    {
                        continue;
                    }

                    var res = CoinChangeHelper(coins, amount - coin);
                    minChange = Math.Min(minChange, res);
                }

                coinSolns[amount] = 1 + minChange;
            }

            return coinSolns[amount];
        }
    }
}