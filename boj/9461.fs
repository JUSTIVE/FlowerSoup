open System

[<EntryPoint>]
let main argv =
    let mutable pdv = [|1I;1I;1I;2I;2I;3I;4I;5I;7I;9I|]
    for i in 0..110 do
        let temp = (pdv.[(pdv.Length-1)] + pdv.[pdv.Length-5]) //)
        pdv <- Array.append pdv [|temp|]
    let ins = Console.ReadLine()|>int
    for i in 0..ins-1 do
        printfn "%A" pdv.[(Console.ReadLine()|>int)-1]
    0