open System
let ins = Console.ReadLine().Split()|>Array.map int|>Array.sort
((ins|>Array.reduce(fun x y -> x+y)) - ins.[0])|>printfn"%d"