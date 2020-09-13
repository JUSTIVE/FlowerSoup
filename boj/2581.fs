open System

let template=[2;3;5;7]

let validateEratosThenes x pt= 
    match pt|>List.forall(fun y-> x%y <> 0) with
    | true -> Some x
    | false -> None

let rec eratosthenes i pt (t:int) =
    match i with
    | ii when ii>t -> pt
    | x -> 
        match validateEratosThenes x pt with
        | Some y -> (y::pt)
        | None   -> pt
        |>eratosthenes (i+1)<|t
        
let M = Console.ReadLine()|>int
let N = Console.ReadLine()|>int

let initialPrimeTable  = template|>List.filter(fun x-> (x>=M && x<=N))

let primeTable = (eratosthenes 11 initialPrimeTable N)|>List.filter (fun x -> x>=M)
match primeTable.IsEmpty with
| true -> printfn "-1"
| false -> printfn "%d\n%d" (primeTable|>List.sum) (primeTable|>List.min)
