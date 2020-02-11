open System
match Console.ReadLine().Split()|>Array.map float with
| [|b;c;p|] when c>=p -> -1
| [|b;c;p|] -> (b/(p-c)|>int) + 1
| __ -> 0
|> printfn "%d" 