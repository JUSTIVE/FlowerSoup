open System

let p = Console.ReadLine().Split()|>Array.map int
let c = Console.ReadLine().Split()|>Array.map int

if p|>Array.filter(fun x->x=c.[0])|>Array.length = 0 then
    printf "%d" 0
else
    for i in 0..((p|>Array.length) - 1) do
        if c.[0] = p.[i] then
            printf "%d" (i+1)