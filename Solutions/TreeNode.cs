using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x, TreeNode left = null, TreeNode right = null)
        {
            val = x;
            this.left = left;
            this.right = right;
        }
    }
}