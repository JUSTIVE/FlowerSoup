open System

let geti () =
    Console.ReadLine()|>int

match geti() with
| a when a > 0->
    match geti() with
    | b when b > 0 -> 1
    | b -> 4
    | __ ->failwith "unknown"
| a ->
    match geti() with
    | b when b > 0 -> 2
    | b -> 3
    | __ ->failwith "unknown"
| __ ->failwith "unknown"
|>printfn "%d"