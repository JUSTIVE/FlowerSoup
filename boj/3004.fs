open System
let v a =
    (a/2)+1
let ins = Console.ReadLine()|>int
match ins % 2 with
| 0 ->
    Math.Pow((v ins)|>float,2.0)|>int
| 1 ->
    v ins * ((ins-ins/2)+1)
|>printfn "%d"