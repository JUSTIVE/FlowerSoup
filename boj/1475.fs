open System

let flip inc =
    match inc with
    | '9' -> '6'
    | __ -> inc

let sixOrNine x =
    match x with
    | '6'
    | '9' -> true
    | __ -> false

Console.ReadLine()
|> Seq.fold
    (fun x y ->
        match x |> Map.tryFind (flip y) with
        | Some v when sixOrNine y -> x |> Map.add '6' (v + 0.5)
        | Some v -> x |> Map.add y (v + 1.0)
        | None when sixOrNine y -> x |> Map.add '6' 0.5
        | None -> x |> Map.add y 1.0)
    Map.empty<char, double>
|> Map.toSeq
|> Seq.fold (fun v (c, d) -> Math.Max(v, d)) 0.0
|> Math.Ceiling
|> int
|> printfn "%d"
