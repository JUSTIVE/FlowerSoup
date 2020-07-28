open System

let intFlip (x:int)=
    x|>string
    |>Seq.rev
    |>String.Concat
    |>int

Console.ReadLine().Split()
|>Array.map int
|>Array.map intFlip
|>Array.sum
|>intFlip
|>printf "%d"