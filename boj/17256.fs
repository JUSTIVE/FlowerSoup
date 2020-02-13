open System
let [|a;b;c|] = Console.ReadLine().Split()|>Array.map int
let [|d;e;f|] = Console.ReadLine().Split()|>Array.map int
printfn "%d %d %d" (d-c) (e/b) (f-a)