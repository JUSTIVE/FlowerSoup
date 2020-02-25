open System

let rec ReadEdge (graphMap:Map<int,seq<int>>) totalEdges currentnum =
    if totalEdges = currentnum then graphMap
    else
        let [|f;t|] = Console.ReadLine().Split()|>Array.map int|>Array.sort
        ReadEdge (match graphMap.TryFind f with
                | Some a ->
                    graphMap|>Map.add f (a|>Seq.append [t])
                | None ->
                    graphMap|>Map.add f (Seq.empty<int>|>Seq.append [t])) totalEdges (currentnum+1)

let getListChildren graphMap fromNode toVisitNodes visitedNodes= 
    match graphMap|>Map.tryFind fromNode with
    | Some v ->
        v
        |>Seq.filter
            (fun x-> 
                not (Set.contains x visitedNodes))
        |>Seq.sort
        |>Seq.toList
    | None -> List.empty<int>

let rec dfs graphMap toVisitNodes (visitedNodes:Set<int>) =
    if toVisitNodes|>List.length = 0 then visitedNodes
    else
        match Map.tryFind toVisitNodes.[0] graphMap with
        | Some adjacentList ->
            adjacentList
            |>List.iter
                (fun x->
                    dfs
                        graphMap
                        (toVisitNodes|>List.append [x])
                        (Set.add x visitedNodes)|>ignore
                    ())
            visitedNodes
        | None ->
            visitedNodes

let doProp graphMap initNode =
    dfs graphMap [initNode] Set.empty<int>|>ignore

let [|n;e;i|] = Console.ReadLine().Split()|>Array.map int
doProp (ReadEdge Map.empty<int,seq<int>> e 0) i