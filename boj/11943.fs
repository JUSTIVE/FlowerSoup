open System
type bucket = (int*int)

let validate d=
    match d with
    | [|a;b|] -> bucket(a,b)
    | __ -> failwith "unknown"
let ind ()=
    Console.ReadLine().Split()|>Array.map int
    |>validate

match ind(),ind() with
| (a,b),(c,d) ->
    Math.Min(a+d,b+c)|>printfn "%d"
| __-> failwith "unknown"