open System

let mp s (x,y) =
    match s|>Map.tryFind x with
    | Some a ->
        s|>Map.add x (a|>Seq.append [y])
    | None ->
        s|>Map.add x (Seq.append Seq.empty<int> [y])

let arr_to_pair (x:int[]) =
    match x with
    | [|x;y|] -> (x,y)
    | _ -> failwith "unexpected"
    
        
let rec ins s i c =
    if i = c-1 then s
    else ins (mp s (Console.ReadLine().Split()|>Array.map int|>arr_to_pair)) (i+1) c

let rec dfs ()=
    ignore    
    
let doProb (d:Map<int,seq<int>>) (b:int) =
    dfs (d,(List.empty<int>|>List.append [b]))
    |>ignore

let [|n;m;v|] = Console.ReadLine().Split()|>Array.map int
ins Map.empty<int,int> 0 (Console.ReadLine()|>int)
|>Map.map(fun k v -> v|>Seq.sortBy(fun (a,b)->a))
|>doProb<|v


