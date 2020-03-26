open System

let rec doProp g=
    if g>0 then
        match Console.ReadLine().Split()|>Array.map int with
        | [|a;b|] ->
            printfn "%d %d" (2*b - a) (a-b)
        doProp (g-1)
        
        
doProp (Console.ReadLine()|>int)