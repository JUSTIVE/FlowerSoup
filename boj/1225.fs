open System
open System.Numerics

let stoi (s:string):bigint = 
    s
    |>Seq.toList
    |>List.map(fun x -> (BigInteger.Parse <|string x))
    |>List.sum

Console.ReadLine().Split()
|>Array.map stoi
|>Array.fold(fun s t->s*t) 1I
|>printfn "%A"