open System
let i = Console.ReadLine()|>double
printfn "%f\n%f" (Math.PI*i*i) (2.0*i*i)