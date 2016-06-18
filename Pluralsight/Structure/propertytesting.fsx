#r @"..\..\packages\FsCheck.2.5.0\lib\net45\FsCheck.dll"

open FsCheck

let appendedListLength l1 l2 = 
    (l1 @ l2).Length = l1.Length + l2.Length

Check.Quick appendedListLength

