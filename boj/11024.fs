open System

let rec doProp g=
    if g>0 then
        Console.ReadLine().Split()
        |>Array.map int
        |>Array.reduce (+)
        |>printfn"%d"
        doProp (g-1)
        
doProp (Console.ReadLine()|>int)