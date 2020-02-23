open System
let geti () =
    Console.ReadLine().Split()
    |>Array.map int
    |>Array.reduce(fun x y -> x * y)
let rec doP s g c =
    if c=g then s
    else doP (s+geti()) g (c+1) 
    
printfn "%d" (doP 0 (Console.ReadLine()|>int) 0)