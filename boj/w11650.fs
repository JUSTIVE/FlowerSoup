open System

let ap (s:seq<int>) (i:int) :seq<int>=
    Seq.rev(Seq.append [i] (s|>Seq.rev))

let um pl x y=
    match pl|>Map.tryFind x with
            | Some a ->
                pl|>Map.add x (ap a y)
            | None -> 
                pl|>Map.add x ([|y|]:>seq<int>)

let rec ins (pl:Map<int,seq<int>>) (i:int) (c:int):Map<int,seq<int>> =
    if i = (c-1) then pl
    else 
        let [|x;y|] = Console.ReadLine().Split()|>Array.map int
        ins (um pl x y) (i+1) c
    
let q = 
    ins Map.empty<int,seq<int>> 0 (Console.ReadLine()|>int)
    |>Map.map (fun k v->Seq.sort v)
    |>Map.toSeq

q|>Seq.sortBy(fun (a,b)-> a) 
|>Seq.map(
    fun (x,y)-> printfn "%d" x
)
