open System

let mp s (x,y) =
    match s|>Map.tryFind x with
    | Some a ->
        s|>Map.add x (a|>Seq.append [y,false])
    | None ->
        s|>Map.add x (Seq.append Seq.empty<int*bool> [(y,false)])

let arr_to_pair (x:int[]) =
    match x with
    | [|x;y|] -> (x,y)
    | _ -> failwith "unexpected"
    
        
let rec ins s i c =
    if i = c-1 then s
    else ins (mp s (Console.ReadLine().Split()|>Array.map int|>arr_to_pair)) (i+1) c

type t = Map <int, Map<int, bool>>


let rec dfs (g:Map<int,seq<int*bool>>) (vl:seq<int>) b = 
    g
    |>Map.toSeq
    |>Seq.sortBy(fun (a,b)->a)
    |>Seq.map(fun (a,b)->
        b
        |>Seq.map(fun y->printfn " "))
    
let doProb (d:Map<int,seq<int*bool>>) (b:int) =
    dfs d Seq.empty<int> b
    |>ignore

let [|n;m;v|] = Console.ReadLine().Split()|>Array.map int
ins Map.empty<int,seq<int*bool>> 0 (Console.ReadLine()|>int)
|>Map.map(fun k v -> v|>Seq.sortBy(fun (a,b)->a))
|>doProb<|v


