open System

let addToMap m k v =
    match m|>Map.tryFind k with
    | Some a ->
        m|>Map.add k (v::a)
    | None ->
        m|>Map.add k [v]
        
let rec initMap s g c =
    if g = c then s
    else
        match Console.ReadLine().Split() with
        | [|age;name|] ->
            initMap (addToMap s (int age) name) g (c+1)

let sorter m=
    m
    |>Map.map (fun k v -> v|>List.rev)
    |>Map.toArray
    |>Array.sortBy(fun (a,b)->a)
    
let printer sm =
    for (age,names) in sm do
        for name in names do
            printfn "%d %s" age name


initMap Map.empty<int,string list> (Console.ReadLine()|>int) 0
|>sorter
|>printer