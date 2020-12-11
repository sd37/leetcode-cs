/*
 * @lc app=leetcode id=1239 lang=csharp
 *
 * [1239] Maximum Length of a Concatenated String with Unique Characters
 *
 * https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/description/
 *
 * algorithms
 * Medium (48.84%)
 * Likes:    624
 * Dislikes: 72
 * Total Accepted:    40.5K
 * Total Submissions: 82.8K
 * Testcase Example:  '["un","iq","ue"]'
 *
 * Given an array of strings arr. String s is a concatenation of a sub-sequence
 * of arr which have unique characters.
 * 
 * Return the maximum possible length of s.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = ["un","iq","ue"]
 * Output: 4
 * Explanation: All possible concatenations are "","un","iq","ue","uniq" and
 * "ique".
 * Maximum length is 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = ["cha","r","act","ers"]
 * Output: 6
 * Explanation: Possible solutions are "chaers" and "acters".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
 * Output: 26
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 16
 * 1 <= arr[i].length <= 26
 * arr[i] contains only lower case English letters.
 * 
 * 
 */

// @lc code=start
// 

// Status = AC
using System;
using System.Linq;
using System.Collections.Generic;

public class MaxLengthConcatenateStringWithUniqueCharacters 
{
    public class SolnDS
    {
        private IList<string> solnPath = new List<string>();

        public int maxLength = int.MinValue;

        public bool IsSafe(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            foreach (var item in solnPath)
            {
                foreach (var ch in s)
                {
                    if(item.Contains(ch))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Add(string s)
        {
            solnPath.Add(s);
            var currentLength = this.solnPath.Sum(x => x.Length);
            if(currentLength > this.maxLength)
            {
                this.maxLength = currentLength;
            }
        }

        public void Remove()
        {
            if(solnPath.Count == 0)
            {
                return;
            }

            solnPath.RemoveAt(solnPath.Count - 1);
        }
    }

    public void MaxLengthHelper(IList<string> currentArray, SolnDS soln, int TotalUniqueChars)
    {
        foreach (var item in currentArray)
        {
            if(soln.IsSafe(item))
            {
                soln.Add(item);

                if(soln.maxLength == TotalUniqueChars)
                {
                    return;
                }

                this.MaxLengthHelper(currentArray, soln, TotalUniqueChars);
            }

            // try next one.
        }

        // pop previous addition.
        soln.Remove();
    }

    public int MaxLength(IList<string> arr)
    {
        if(arr == null || arr.Count == 0)
        {
            return 0;
        }
        
        var filteredArray = arr.Where(x => x.Distinct().Count() == x.Length).ToArray();
        
        if(filteredArray.Length == 0)
        {
            return 0;
        }

        int totalUniqueChars = filteredArray.SelectMany(x => x.ToCharArray()).Distinct().Count();

        var soln = new SolnDS();

        this.MaxLengthHelper(filteredArray, soln, totalUniqueChars);
        return soln.maxLength;
    }
}
