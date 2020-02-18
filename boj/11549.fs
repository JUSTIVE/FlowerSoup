open System

let i m w =
    match m|>Map.tryFind w with
    | Some a -> a+1
    | None -> 1

let f m a =
    match m|>Map.tryFind a with
    | Some w -> w
    | None -> 0

let g () =
    Console.ReadLine()

let dfd q1 i1 a1 =
    Array.fold a1 i1 q1

let c a q=
    printfn
        "%d" 
        (f (dfd q Map.empty<int,int> (fun s x-> s|>Map.add x (i s x))) a)
    |>ignore

c (g()|>int) (g().Split()|>Array.map int)
|>ignore