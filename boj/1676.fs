open System
open System

let v = Console.ReadLine()|>int

let rec f t d s=
    match t%d with
    | 0 -> (f (t/d) d (s+1))
    | _ -> s

let rec ac t s d ca=
    match s with
    | x1 when t>=s->
        (ac t (s+1) d (ca+(f s d 0)))
    | _ -> ca

let acr x d = (ac x 1 d 0)
let gm x = 
    [5;2]
    |>List.map(fun a->(acr x a))
    |>List.reduce(fun a' b' -> Math.Min(a',b'))

match v with
| 0 -> 0
| x -> gm x
|>printfn "%d"