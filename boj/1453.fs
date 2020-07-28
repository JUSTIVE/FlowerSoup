open System

Console.ReadLine()|>ignore

let accMap (m:Map<int,int>) (x,y) = 
    m
    |>Map.add x (
        match m|>Map.tryFind x with
        | Some v->(y+v)
        | None ->y)
let accList s (x,y) = 
    s + (y-1)

Console.ReadLine().Split()
|>Array.map (fun x->(int x,1))
|>Array.fold accMap Map.empty<int,int>
|>Map.toList
|>List.filter (fun (x,y)->y>=2)
|>List.fold accList 0
|>printf "%d"