open System

let doAction inA =
    match inA with
    | [|a;b|]->
        match (a%10) with
        | 2 -> [|6;2;4;8|].[b%4]
        | 3 -> [|1;3;9;7|].[b%4]
        | 4 -> [|6;4|].[b%2]
        | 7 -> [|1;7;9;3|].[b%4]
        | 8 -> [|6;8;4;2|].[b%4]
        | 9 -> [|1;9|].[b%2]
        | 0 -> 10
        | x -> x

let rec doProp g c =
    if g=c then ()
    else
        doAction (Console.ReadLine().Split()|>Array.map int)
        |>printfn "%d"
        doProp g (c+1)

doProp (Console.ReadLine()|>int) 0