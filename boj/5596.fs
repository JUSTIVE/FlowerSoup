open System
let doin ()=
    Console.ReadLine()
        .Split()
    |>Array.map int
    |>Array.reduce (fun  x y -> x+y)
Math.Max(doin(),doin())|> printfn "%d"