open System
let ins = Console.ReadLine().Split()|>Array.map(fun x -> (int x)+1)
printfn "%d" (Math.Floor(float((ins.[0]*ins.[1]/ins.[2])-1))|>int)