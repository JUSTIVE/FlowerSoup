open System

let mp s (x,y) =
    let mutable  aa,bb = 0,0
    if x>y then
        aa<-y
        bb<-x
    else
        aa<-x
        bb<-y
        
    match s|>Map.tryFind aa with
    | Some a ->
        s|>Map.add aa (a|>Seq.append [bb])
    | None ->
        s|>Map.add aa (Seq.append Seq.empty<int> [bb])

let arr_to_pair (x:int[]) =
    match x with
    | [|x;y|] -> (x,y)
    | _ -> failwith "unexpected"
    
        
let rec ins s i c =
    if i = c then s
    else ins (mp s (Console.ReadLine().Split()|>Array.map int|>arr_to_pair)) (i+1) c

let validCandidate (graph:Map<int,seq<int>>) (index:int) (visitiedList:Set<int>) =
    match graph|>Map.tryFind index with
    | Some v ->
        v
        |>Seq.toList
        |>List.filter(fun x-> Set.exists (fun y -> x<>y) visitiedList)
        |>List.sort
    | None -> List.empty<int>

let rec dfs graph toVisitList visitiedList =
    if toVisitList|>List.length = 0 then graph
    else
        match toVisitList with
        | h::t ->
            printf "%d " h
            dfs graph (t|>List.append (validCandidate graph h visitiedList)) (visitiedList|>Set.add h)
        | []->
            dfs graph List.empty<int> Set.empty<int>
    

    
let doProb (d:Map<int,seq<int>>) (b:int) =
    dfs d (List.empty<int>|>List.append [b]) (Set.empty<int>|>Set.add b)
    |>ignore

let [|n;m;v|] = Console.ReadLine().Split()|>Array.map int
ins Map.empty<int,seq<int>> 0 m
|>Map.map(fun k v -> v|>Seq.sort)
|>doProb<|v


