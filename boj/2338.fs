open System
open System.Numerics

let (a,b) = Console.ReadLine()|>bigint.TryParse
let (c,d) = Console.ReadLine()|>bigint.TryParse
printfn "%A\n%A\n%A" (b+d) (b-d) (b*d) 