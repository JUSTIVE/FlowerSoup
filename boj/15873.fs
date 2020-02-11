open System
match Console.ReadLine() with
| a when a.[1]='0'->
    match a with
    | a when Seq.length a = 3 ->
        10 + (a.[2]|>int)-48
    | __ -> 20
| __ ->
    match __ with
    | a when Seq.length __ = 2 ->
        (__ 
        |> Seq.map int 
        |> Seq.reduce (fun x y -> x+y))-96
    | __ ->
        (__.[0]|>int) - 38
|> printfn "%d"