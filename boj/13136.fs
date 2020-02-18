open System

let cv (a:float) b = 
    Math.Ceiling(a/ b)
match Console
    .ReadLine()
    .Split()
    |>Array.map float with
| [|a;b;c|] ->
    (cv a c * cv b c)
| __-> failwith "unknown"
|>bigint
|> printfn "%A"