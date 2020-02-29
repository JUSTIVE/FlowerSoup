open System

match Console.ReadLine().Split()|>Array.map int with
| [|x;l;r|] when x<=l -> l
| [|x;l;r|] when x>=r -> r
| [|x;l;r|] -> x
| __-> failwith ""
|> printfn "%d"