open System
match Console.ReadLine().Split()|>Array.map int with
| [|a;b|]->Math.Max(a,b)    
| __-> failwith "f"
|> printfn "%d"