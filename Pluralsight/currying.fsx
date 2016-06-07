let distance x y = x - y |> abs
let distanceFrom5 = distance 5

distanceFrom5 -5
(distance 5) 2
distance 5 2

let (|><|) x y = x - y |> abs

5 |><| 2 |><| 10

