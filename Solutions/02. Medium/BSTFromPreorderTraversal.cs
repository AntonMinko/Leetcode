using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1008. Construct Binary Search Tree from Preorder Traversal

    Link: https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/
    
    Difficulty: Medium

Return the root node of a binary search tree that matches the given preorder traversal.

(Recall that a binary search tree is a binary tree where for every node, any descendant of 
node.left has a value < node.val, and any descendant of node.right has a value > node.val.  
Also recall that a preorder traversal displays the value of the node first, 
then traverses node.left, then traverses node.right.)

Example 1:
Input: [8,5,1,7,10,12]
Output: [8,5,10,1,7,null,12]

Note: 
    1 <= preorder.length <= 100
    The values of preorder are distinct.
    */

    public class BSTFromPreorderTraversal
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = new TreeNode(preorder[0]);
            BuildChildNode(root, preorder, 1, int.MinValue, int.MaxValue);

            return root;
        }

        private int BuildChildNode(TreeNode current, int[] preorder, int index, int lo, int hi)
        {
            if (index == -1 || index >= preorder.Length) return -1;
            int num = preorder[index];
            if ( lo < num && num < current.val)
            {
                TreeNode leftChild = new TreeNode(num);
                current.left = leftChild;
                index = BuildChildNode(leftChild, preorder, ++index, lo, current.val);
                if (index == -1 || index >= preorder.Length) return -1;
                num = preorder[index];
            }

            if (current.val < num && num < hi)
            {
                TreeNode rightChild = new TreeNode(num);
                current.right = rightChild;
                index = BuildChildNode(rightChild, preorder, ++index, current.val, hi);
            }

            return index;
        }
    }

}