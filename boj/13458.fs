open System
[<EntryPoint>]
let main argv=
    let inline r ()= 
        Console.ReadLine().Split([|' '|])
        |> Array.map int64
    let n = 
        r()
        |> Array.get <| 0
    let mutable A = r()
    let x = r()
    let b,c =
        Array.get x 0, Array.get x 1
    A 
    |> Array.map (fun x -> x-b)
    |> Array.map (
        fun x -> 
            match x with
            | x when x>0L ->
                if x%c = 0L then
                    x/c
                else
                    x/c + 1L
            | _ -> 0L
            )
    |> Array.fold (fun x y -> x+y) 0L
    |> (+) (int64 A.Length)
    |> printfn "%d"
    0