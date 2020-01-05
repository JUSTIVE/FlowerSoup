open System
[<EntryPoint>]
let main argv=
    let n = 
        Console.ReadLine().Split([|' '|])
        |> Array.map int64
        |> Array.get <| 0
    let mutable A =
        Console.ReadLine().Split([|' '|])
        |> Array.map int64
    let x =
        Console.ReadLine().Split([|' '|])
        |> Array.map int64
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