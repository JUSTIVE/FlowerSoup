open System

let distd (d:(int*int)) j =
    match d,j with
    | (x1,y1),(x2,y2) ->
        Math.Abs(x2 - x1) + Math.Abs(y2 - y1)
    | __-> failwith "unknown"

let distb (b:(int*int)) j = 
    match b,j with
    | (x1,y1),(x2,y2) ->
        Math.Max(Math.Abs(x2-x1),Math.Abs(y2-y1))
    | __-> failwith "unknown"

let getp ()= 
    match Console.ReadLine().Split()|>Array.map int with
    | [|x;y|] -> (x,y)
    | __-> failwith "unknown"

let bessie = getp()
let daisy = getp()
let john = getp()

match (distb bessie john),(distd daisy john) with
| a,b ->
    if a = b then "tie"
    else if a < b then "bessie"
    else "daisy"
| __ -> failwith "unknown"
|> printfn "%s"