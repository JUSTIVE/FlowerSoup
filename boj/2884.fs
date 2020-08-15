open System
let calcTime x y =
    match x,y with
    | x1,y1 when y-45>=0 -> (x1,y-45)
    | x2,y2 when (y-45<0) && (x2 <> 0) -> (x2-1,y2+15)
    | x3,y3 -> (23,y3+15)

let printTime (x,y)=
    printfn "%d %d" x y


match Console.ReadLine().Split()|>Array.map int with
| [|x;y|]->
    calcTime x y
    |>printTime
| __->()