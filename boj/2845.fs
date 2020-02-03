open System

[<EntryPoint>]
let main argv =
    let sum =
        Console.ReadLine().Split(' ')
        |> Array.map int
        |> Array.reduce(fun x y -> x * y)
    Console.ReadLine().Split(' ')
    |> Array.map(fun x ->
        printf "%d " ((int x) - sum))
    0