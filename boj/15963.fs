open System
match Console.ReadLine().Split()|>Array.map bigint.TryParse with
| [|(a,b);(c,d)|] when a&&c&&b=d -> 1
| __->0
|> printfn "%d"