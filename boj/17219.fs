open System

let rec inh s g c =
    if g=c then s
    else
        match Console.ReadLine().Split() with
        | [|a;b|]->
            inh (s|>Map.add a b) g (c+1)
        | __->
            failwith "unknown"    

let rec doProp m g c =
    if g=c then ()
    else
        match m|>Map.tryFind (Console.ReadLine()) with
        |Some a ->
            printfn "%s" a
            doProp m g (c+1)
        |None ->
            failwith "unknown"

match Console.ReadLine().Split()|>Array.map int with
| [|a;b|] ->
    doProp
        (inh Map.empty<string,string> a 0)
        b 0
| __->
    failwith "unknown"