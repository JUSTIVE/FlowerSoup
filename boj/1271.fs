open System
let [|(a,b);(c,d)|] = Console.ReadLine().Split()|>Array.map bigint.TryParse
printfn "%A\n%A" (b/d) (b%d)