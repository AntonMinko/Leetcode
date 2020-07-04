using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class FindTwoIndexes
    {
    /*
    1. Two Sum

    Link: https://leetcode.com/problems/two-sum/
    
    Difficulty: Easy

    Given an array of integers, return indices of the two numbers such that they add up to a specific target.

    You may assume that each input would have exactly one solution, and you may not use the same element twice.

    Example:

    Given nums = [2, 7, 11, 15], target = 9,

    Because nums[0] + nums[1] = 2 + 7 = 9,
    return [0, 1].
   
    */
        private class Num
        {
            public int Index { get; set; }
            public int Value { get; set; }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var orderedNums = new List<Num>();
            for (int i = 0; i < nums.Length; i++)
            {
                orderedNums.Add(new Num() { Index = i, Value = nums[i] });
            }
            orderedNums.Sort((x, y) => {return x.Value.CompareTo(y.Value);});

            for (int i = 0; i < orderedNums.Count - 1; i++)
            {
                int searchFor = target - orderedNums[i].Value;
                for (int j = i + 1; j < orderedNums.Count; j++)
                {
                    if (orderedNums[j].Value == searchFor)
                    {
                        return new[] { orderedNums[i].Index, orderedNums[j].Index };
                    }
                    if (orderedNums[j].Value > searchFor)
                    {
                        break;
                    }
                }
            }
            return new[] { -1, -1 };
        }

    }
}