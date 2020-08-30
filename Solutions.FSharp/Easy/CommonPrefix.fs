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