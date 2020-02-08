open System

let action() = 
    let ins = Console.ReadLine().Split(' ')|>Array.map int
    printfn "%d%02d" (ins.[2] % ins.[0]) (ins.[1]/ins.[0])
    ignore
[<EntryPoint>]
let main argv =
    let c = Console.ReadLine()|>int
    for i in 0..c do
        action()
    0