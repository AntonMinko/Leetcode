using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions
{
    public static class TreeNodeHelpers
    {
        public static string ToStringBFS(this TreeNode root)
        {
            if (root == null) return "[]";

            var sb = new StringBuilder();
            sb.Append("[");
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool isFirstValue = true;

            while (queue.Any())
            {
                int nodesOnCurLevel = queue.Count;
                for (int i = 0; i < nodesOnCurLevel; i++)
                {
                    var node = queue.Dequeue();
                    sb.Append(isFirstValue ? string.Empty : ',');
                    isFirstValue = false;
                    sb.Append(node != null ? node.val : "null");

                    if (node?.left != null || node?.right != null)
                    {
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}