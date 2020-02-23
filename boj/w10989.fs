open System

let gnvfm m k =
    match m|>Map.tryFind k with
    | Some a -> a+1
    | None -> 1
let a2m m k =
    m|>Map.add k (gnvfm m k)
let rec doA s g c=
    if c=g then s
    else doA (a2m s (Console.ReadLine()|>int)) g (c+1)

let rec doP (v,g) c =
    if g=c then ignore
    else
        printfn "%d" v
        doP (v,g) (c+1)

doA Map.empty<int,int> (Console.ReadLine()|>int) 0
|>Map.toSeq
|>Seq.sortBy(fun (a,b)-> a)
|>Seq.map (fun x -> doP x 0)
|>ignore