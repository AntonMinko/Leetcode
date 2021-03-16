using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    714. Best Time to Buy and Sell Stock with Transaction Fee

    Link: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/
    
    Difficulty: Medium

You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.
Find the maximum profit you can achieve. You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.
Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

Example 1:
Input: prices = [1,3,2,8,4,9], fee = 2
Output: 8
Explanation: The maximum profit can be achieved by:
- Buying at prices[0] = 1
- Selling at prices[3] = 8
- Buying at prices[4] = 4
- Selling at prices[5] = 9
The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.

Example 2:
Input: prices = [1,3,7,5,10,3], fee = 3
Output: 6

 

Constraints:

    1 < prices.length <= 5 * 10^4
    0 < prices[i], fee < 5 * 10^4

    Complexity:
        O(n) time complexity
        O(1) space complexity
    */
    public class BuyAndSellWithFee
    {
        public int MaxProfit(int[] prices, int fee)
        {
            if (prices.Length < 2) return 0;

            int profit = 0;
            int buyPrice = prices[0];
            int sellPrice = -1;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > sellPrice && prices[i] > buyPrice + fee)
                {
                    sellPrice = prices[i];
                }
                else if (prices[i] < sellPrice - fee)
                {
                    profit += sellPrice - buyPrice - fee;
                    buyPrice = prices[i];
                    sellPrice = -1;
                }
                else if (prices[i] < buyPrice)
                {
                    buyPrice = prices[i];
                    sellPrice = -1;
                }
            }

            if (sellPrice - buyPrice - fee > 0)
            {
                profit += sellPrice - buyPrice - fee;
            }

            return profit;
        }
    }

}