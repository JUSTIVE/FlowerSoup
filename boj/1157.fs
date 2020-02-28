open System
let ins=
    Console.ReadLine().ToUpper()
    |>Seq.fold(fun m x ->
        match m|>Map.tryFind x with
        | Some v->m|>Map.add x (v+1)
        | None->m|>Map.add x 1) 
        Map.empty<char,int>
    |>Map.toSeq
    |>Seq.sortByDescending(fun (a,b)-> b)
if ins|>Seq.length = 1 
then 
    match ins|>Seq.item 0 with
    | (a,b) -> a
else
    match (ins|>Seq.item 0),(ins|>Seq.item 1) with
    | (a,b),(c,d) when b=d ->'?'
    | (a,b),(c,d)->a
|>printfn"%c"