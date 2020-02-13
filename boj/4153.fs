open System
let p a b c =
    Math.Pow(b,2.0)+Math.Pow(c,2.0) = Math.Pow(a,2.0)
let rec f() =
    match Console.ReadLine()
              .Split()
          |>Array.map float
          |>Array.sortDescending with
    | [|0.0;0.0;0.0|] ->
        ignore
    | [|a;b;c|] ->
        match p a b c with
        | true -> "right"
        | false -> "wrong"
        |> printfn "%s"
        f()
    |__-> ignore
f()|>ignore