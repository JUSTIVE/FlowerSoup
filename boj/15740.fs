open System
open System.Numerics

[<EntryPoint>]
let main argv =
    printfn "%A"
        (Console
            .ReadLine()
            .Split(' ')
            |> Array.map(fun x ->
                let v,r = bigint.TryParse(x)
                r) 
            |> Array.reduce(fun (x) (y) -> x + y))
    0