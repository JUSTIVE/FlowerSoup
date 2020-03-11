open System

let rec getter s g c =
    if g=c then s
    else
        getter (s + (Console.ReadLine()|>bigint.Parse)) g (c+1)

let solvr ()=
    match getter 0I (Console.ReadLine()|>int) 0 with
    | x when x>0I -> "+"
    | x when x=0I -> "0"
    | __ -> "-"

let rec doProp g c =
    if g=c then ()
    else
        solvr()|>printfn "%s"
        doProp g (c+1)

doProp 3 0