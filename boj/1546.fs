open System
let c=
    Console.ReadLine()
    |>float
let ins=
    Console.ReadLine().Split()
    |>Array.map float
(ins
|>Array.map(
    fun x->
        x/(ins|>Array.max)*100.0)
|>Array.sum)/c
|>printfn "%.6f"