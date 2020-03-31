open System

let checkHan (inv:int) =
    if inv <100 then true
    else
        string inv
        |>Seq.map int
        |>Seq.windowed 2
        |>Seq.map (fun x-> x|>Array.reduce (-))
        |>Seq.distinct
        |>Seq.length = 1
    
let rec doHan s c=
    if s < 1 then c
    else
        doHan (s-1) (if checkHan s then (c+1) else c)
        
doHan (Console.ReadLine()|>int) 0
|>printf "%d"