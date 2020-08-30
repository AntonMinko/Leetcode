    (*
    Link: https://leetcode.com/problems/longest-common-prefix/
    
    Difficulty: Easy

Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

Example 1:

Input: ["flower","flow","flight"]
Output: "fl"

Example 2:

Input: ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

Note:

All given inputs are in lowercase letters a-z.

    *)
module Solutions.FSharp.Easy.CommonPrefix

    let rec getCommonPrefix (str1 :List<char>, str2: List<char>) =
        let (s1, s2) = if str1.Length > str2.Length then (str2, str1)
                        else (str1, str2)
        if s1.Length > 0 && s1.[0] = s2.[0] then
            s1.[0] :: getCommonPrefix(List.tail s1, List.tail s2)
        else 
            List<char>.Empty
    
    let rec getCommonPrefixList list commonStr =
        match list with
        | [] -> commonStr
        | head :: tail -> getCommonPrefix (Seq.toList commonStr, Seq.toList head) |> getCommonPrefixList tail

    let longestCommonPrefix strs =
        match strs with
        | [ head ] -> head
        | head :: tail -> new string [| for c in getCommonPrefixList tail (Seq.toList head) -> c |]
        | _ -> ""

//Test
    let strs = ["hello"; "hello"; "hi"]
    let prefix = longestCommonPrefix strs