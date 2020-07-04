using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    124. Binary Tree Maximum Path Sum

    Link: https://leetcode.com/problems/binary-tree-maximum-path-sum/
    
    Difficulty: Hard

Given a non-empty binary tree, find the maximum path sum.

For this problem, a path is defined as any sequence of nodes from some starting node to any 
node in the tree along the parent-child connections. The path must contain at least one node 
and does not need to go through the root.
    */
    public class BinaryTreeMaxPathSum
    {
        private int _globalMaxSum;
        public int MaxPathSum(TreeNode root)
        {
            _globalMaxSum = int.MinValue;
            CalculatePathSum(root);
            return _globalMaxSum;
        }

        private int? CalculatePathSum(TreeNode node)
        {
            if (node == null) return null;

            int? leftPathSum = CalculatePathSum(node.left);
            int leftSum = leftPathSum != null ? Math.Max(leftPathSum.Value+node.val, node.val):node.val;
            int? rightPathSum = CalculatePathSum(node.right);
            int rightSum = rightPathSum != null ? Math.Max(rightPathSum.Value+node.val, node.val):node.val;
            
            int maxPathSum = Math.Max(Math.Max(leftSum, rightSum), node.val);
            int nodeSum = leftSum + rightSum - node.val;
            _globalMaxSum = Math.Max(_globalMaxSum, nodeSum);

            return maxPathSum;
        }
    }

}