open System
[<EntryPoint>]
let main argv =
    let mutable t= Console.ReadLine().Split([|' '|])|>Array.map int
    let mutable r=t.[0]
    while t.[0]>=t.[1] do
        r <- r + (t.[0]/t.[1])
        t.[0] <- t.[0]/t.[1]
    printfn "%d" r
    0