open System

[<EntryPoint>]
let main argv =
    let formatter x =
        match x with
        | [| a; b |] when (a > b) -> ">"
        | [| a; b |] when a = b -> "=="
        | __ -> "<"

    printfn
        "%s"
        (Console.ReadLine().Split()
         |> Array.map int
         |> formatter)

    0
