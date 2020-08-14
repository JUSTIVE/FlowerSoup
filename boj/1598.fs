open System

type Coord = (int * int)

let calcCoord (x:int):Coord = Coord(((x-1)/4),((x-1)%4))
let diffCoord (a:int) (b:int):int = Math.Abs (a - b)
let coordDiff (x1:int,y1:int) (x2:int,y2:int) =
    (diffCoord x1 x2) + (diffCoord y1 y2)


match (Console.ReadLine().Split()
    |>Array.map(fun x->calcCoord(int x))) with
    | [|a;b|] ->
        printfn "%d" <| coordDiff a b
    | __ -> ()
