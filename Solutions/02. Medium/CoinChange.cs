using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    322. Coin Change

    Link: https://leetcode.com/problems/coin-change/
    
    Difficulty: Medium

You are given coins of different denominations and a total amount of money amount. Write a function
to compute the fewest number of coins that you need to make up that amount. If that amount of money
cannot be made up by any combination of the coins, return -1.

You may assume that you have an infinite number of each kind of coin.

Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0

Example 4:
Input: coins = [1], amount = 1
Output: 1

Example 5:
Input: coins = [1], amount = 2
Output: 2

Constraints:
    1 <= coins.length <= 12
    1 <= coins[i] <= 231 - 1
    0 <= amount <= 104
    
    Complexity:
        N = coins.Length, M = amount
        O(N*M) time complexity
        O(M) space complexity
    */
    public class CoinChange
    {
        public int GetCoinChange(int[] coins, int amount)
        {
            var memo = new Dictionary<int, int>();

            int GetCoinChange(int curAmount)
            {
                if (curAmount < 0) return -1;
                if (curAmount == 0) return 0;
                if (memo.ContainsKey(curAmount)) return memo[curAmount];

                int minCoins = int.MaxValue;
                foreach (int coin in coins)
                {
                    if (coin <= curAmount)
                    {
                        int remainderCoins = GetCoinChange(curAmount - coin);
                        if (remainderCoins != -1 && minCoins > remainderCoins + 1)
                        {
                            minCoins = remainderCoins + 1;
                        }
                    }
                }

                minCoins = minCoins != int.MaxValue
                    ? minCoins
                    : -1;
                memo[curAmount] = minCoins;

                return minCoins;
            }

            return GetCoinChange(amount);
        }
    }
}