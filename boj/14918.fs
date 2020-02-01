open System

[<EntryPoint>]
let main argv =
    printfn "%d"
        (Console.ReadLine().Split " "
         |> Array.map (fun x -> int x)
         |> Array.reduce (fun x y -> x + y))
    0
