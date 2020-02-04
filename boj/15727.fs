open System
[<EntryPoint>]
let main argv =
    let ins = Console.ReadLine()|>int
    printfn "%d" (if(ins % 5 = 0)then (ins / 5 ) else(ins / 5 + 1))  
    0