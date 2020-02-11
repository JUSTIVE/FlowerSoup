open System
let [|x;y;w;h|] = Console.ReadLine().Split()|>Array.map int
printfn "%d" (Math.Min((Math.Min(x,w-x)),(Math.Min(y,h-y))))