open System

[<EntryPoint>]
let main argv =
    let ins = 
        Console.ReadLine().Split(' ')
        |> Array.map(fun x -> int x)
    printfn "%d %d" (ins.[2]/ins.[1]) (ins.[2]%ins.[1])
    0