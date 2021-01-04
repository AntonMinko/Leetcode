    (*

    139. Word Break

    Link: https://leetcode.com/problems/word-break/
    
    Difficulty: Medium

    Keywords: Dynamic Programming

Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

Note:
    The same word in the dictionary may be reused multiple times in the segmentation.
    You may assume the dictionary does not contain duplicate words.

Example 1:
Input: s = "leetcode", wordDict = ["leet", "code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple", "pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
             Note that you are allowed to reuse a dictionary word.

Example 3:
Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
Output: false


    

    *)

module Solutions.FSharp.Medium.WordBreak
    open System.Collections.Generic


    let wordBreak (s : string) (wordDict : string list) =
        let startAtIndexWith (word : string) (s : string) (startIndex : int) =
            s.IndexOf(word, startIndex) = startIndex
        
        let memoize f = 
            let cache = new Dictionary<int,bool>()
            (fun startIndex ->
                let contains, result = cache.TryGetValue(startIndex)
                if contains then result
                else
                    let result = f startIndex
                    cache.Add(startIndex, result)
                    result)

        let rec wordBreak' = memoize (fun startIndex -> 
            if s.Length = startIndex then true
            else
                match wordDict |> List.filter (fun word -> startAtIndexWith word s startIndex) with
                | [] -> false
                | list -> List.exists (fun (word : string) -> wordBreak' (startIndex + word.Length)) list
        )
        
        wordBreak' 0 


//Test
    let s1 = "leetcode"
    let wordDict1 = ["leet"; "code"]
    let canBreak1 = wordBreak s1 wordDict1   //Expected: true

    let s2 = "applepenapple"
    let wordDict2 = ["apple"; "pen"]
    let canBreak2 = wordBreak s2 wordDict2   //Expected: true

    let s3 = "catsandog"
    let wordDict3 = ["cats"; "dog"; "sand"; "and"; "cat"]
    let canBreak3 = wordBreak s3 wordDict3   //Expected: false