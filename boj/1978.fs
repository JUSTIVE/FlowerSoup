open System
let initialPrimeTable =[2;3;5;7]

let validateEratosThenes x pt= 
    match pt|>List.forall(fun y-> x%y <> 0) with
    | true -> Some x
    | false -> None

let rec eratosthenes i pt =
    match i with
    | ii when ii>1000 -> pt
    | x -> 
        match validateEratosThenes x pt with
        | Some y -> (y::pt)
        | None   -> pt
        |>eratosthenes (i+1)

let primeTable = eratosthenes 11 initialPrimeTable
let checkPrime x =
    primeTable
    |>List.contains x
    |>Convert.ToInt32

Console.ReadLine()|>ignore
Console.ReadLine().Split()
|>Array.map(
    fun x->
        (int x)|>checkPrime)
|>Array.sum
|>printfn "%d"