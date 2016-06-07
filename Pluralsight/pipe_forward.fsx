sin 7.
7. |> sin

7.
|> sin
|> ((*) 2.)

let square x = x * x

3 |> double |> square

[1;2;3;4]
|> List.filter (fun i -> i % 2 = 0)
|> List.map ((*)2)
|> List.sum

let (|<><><>|) a f = f a

3 |<><><>| double |<><><>| square