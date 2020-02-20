open System
let rec c2pw i c =
    if c>30 then 0
    else
        if float i = Math.Pow(2.0,float c) then 1
        else c2pw i (c+1)
let doProp i =
    printfn "%d" (c2pw i 0)
doProp (Console.ReadLine()|>int)