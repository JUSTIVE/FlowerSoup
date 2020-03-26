open System

let rec doProp g=
    if g>0 then
        let ev = Console.ReadLine().Split()|>Array.map int|>Array.filter (fun x->x%2=0)
        printfn "%d %d" (ev|>Array.reduce (+)) (ev|>Array.sort).[0]
        doProp (g-1)
doProp (Console.ReadLine()|>int)