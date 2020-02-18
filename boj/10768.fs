open System

let geti ()= 
    Console.ReadLine()|>int
match (geti(),geti()) with
| (a,b) when a = 2->
    if b > 18 then "After"
    else if b = 18 then "Special"
    else  "Before"
| (a,b) when a > 2 -> "After"
| (a,b) when a < 2 -> "Before"
| __ -> failwith "unknown"
|>printfn "%s"