open System

match (Console.ReadLine().Split()
    |>Array.map int) with
| [|a;b;c|] when a + b + c >= 100-> "OK"
| [|a;b;c|] ->
    match [("Soongsil",a);("Korea",b);("Hanyang",c)]
        |>Seq.sortBy(fun (a,b)->b)
        |>Seq.head with
    | (a,b) -> a
| __ -> failwith "unknown"
|> printfn "%s"