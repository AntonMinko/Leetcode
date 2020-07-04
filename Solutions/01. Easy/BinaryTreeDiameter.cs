using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{

    public class BinaryTreeDiameter
    {
        private int _maxDiameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            CalculatePath(root);
            return _maxDiameter;
        }

        private int CalculatePath(TreeNode node)
        {
            if (node is null) return 0;

            int leftPath = CalculatePath(node.left);
            int rigthPath = CalculatePath(node.right);

            int nodeDiameter = leftPath + rigthPath;
            _maxDiameter = Math.Max(_maxDiameter, nodeDiameter);

            return Math.Max(leftPath, rigthPath) + 1;
        }
    }
}