open System
[<EntryPoint>]
let main argv =
    let ins = Console.ReadLine().Split(' ')|>Array.map int
    printfn "%d" (((ins.[0] - 1) / ins.[1]) * ins.[2] * ins.[3])
    0