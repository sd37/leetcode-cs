/*
 * @lc app=leetcode id=543 lang=csharp
 *
 * [543] Diameter of Binary Tree
 *
 * https://leetcode.com/problems/diameter-of-binary-tree/description/
 *
 * algorithms
 * Easy (48.89%)
 * Likes:    3859
 * Dislikes: 229
 * Total Accepted:    403.7K
 * Total Submissions: 825.7K
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * 
 * Given a binary tree, you need to compute the length of the diameter of the
 * tree. The diameter of a binary tree is the length of the longest path
 * between any two nodes in a tree. This path may or may not pass through the
 * root.
 * 
 * 
 * 
 * Example:
 * Given a binary tree 
 * 
 * ⁠         1
 * ⁠        / \
 * ⁠       2   3
 * ⁠      / \     
 * ⁠     4   5    
 * 
 * 
 * 
 * Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].
 * 
 * 
 * Note:
 * The length of path between two nodes is represented by the number of edges
 * between them.
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

// status = AC
namespace dev
{
    using System;
    using System.Linq;
    using System.Collections;
    using dev.objects;

    public class DiameterOfBinaryTreeProblem
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            var nodes = DiameterHelper(root);
            return nodes - 1;
        }
        
        private int DiameterHelper(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            int lheight = GetHeight(root.left);
            int rheight = GetHeight(root.right);
            int ldiameter = DiameterHelper(root.left);
            int rdiameter = DiameterHelper(root.right);

            return Math.Max(lheight + rheight + 1, Math.Max(ldiameter, rdiameter));
        }

        private int GetHeight(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
    }
}

