open System
let t = Console.ReadLine()|>int
for i in 0..t-1 do
    let [|h;w;n|] = Console.ReadLine().Split()|>Array.map int
    let f = if n%h=0 then h else n%h
    let r = if n%h=0 then n/h else ((n/h)+1)    
    printfn "%d%02d" f r