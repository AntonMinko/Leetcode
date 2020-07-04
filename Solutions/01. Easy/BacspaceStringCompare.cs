using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    844. Backspace String Compare

    Link: https://leetcode.com/problems/backspace-string-compare/
    
    Difficulty: Easy

    Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.

Example 1:

Input: S = "ab#c", T = "ad#c"
Output: true
Explanation: Both S and T become "ac".

Example 2:

Input: S = "ab##", T = "c#d#"
Output: true
Explanation: Both S and T become "".

Example 3:

Input: S = "a##c", T = "#a#c"
Output: true
Explanation: Both S and T become "c".

Example 4:

Input: S = "a#c", T = "b"
Output: false
Explanation: S becomes "c" while T becomes "b".

Note:
    1 <= S.length <= 200
    1 <= T.length <= 200
    S and T only contain lowercase letters and '#' characters.

Follow up:
    Can you solve it in O(N) time and O(1) space?

    */
    public class BacspaceStringCompare
    {
        public bool BackspaceCompare(string S, string T) {
            var enumS = GetCharsToCompare(S).GetEnumerator();
            var enumT = GetCharsToCompare(T).GetEnumerator();

            while(enumS.MoveNext())
            {
                if (!enumT.MoveNext())
                {
                    return false;
                }

                char curS = enumS.Current;
                char curT = enumT.Current;
                if(curS != curT)
                {
                    return false;
                }
            }

            return !enumT.MoveNext();
    }
    
    private IEnumerable<char> GetCharsToCompare(string str)
    {
        int backspacesCount = 0;
        for(int i=str.Length-1; i>= 0; i--)
        {
            if (str[i] == '#')
            {
                backspacesCount++;
            }
            else
            {
                if (backspacesCount > 0)
                {
                    backspacesCount--;
                }
                else
                {
                    yield return str[i];
                }
            }
        }
    }
    }

}