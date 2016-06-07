let minus1 x = x - 1
let times2 = (*) 2

minus1 9
times2 8

times2 (minus1 9)

let minus1ThenTimes2 = times2 << minus1
minus1ThenTimes2 9
(times2 << minus1) 9
times2 << minus1 <| 9

minus1 (times2 9)
let times2ThenMinus1 = times2 >> minus1
times2ThenMinus1 9