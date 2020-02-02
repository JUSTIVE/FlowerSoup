open System
open System.Numerics

[<EntryPoint>]
let main argv =
    printfn "%A"
        (Console
            .ReadLine()
            .Split(' ')
            |> Array.map(fun x -> bigint (int x)) 
            |> Array.reduce(fun x y -> x + y))
    0