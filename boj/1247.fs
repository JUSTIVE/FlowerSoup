open System

let rec getter s g c =
    match g=c with
    | true -> s
    | false -> getter (s + (Console.ReadLine()|>bigint.Parse)) g (c+1)

let solvr ()=
    match getter 0I (Console.ReadLine()|>int) 0 with
    | x when x>0I -> "+"
    | x when x=0I -> "0"
    | __ -> "-"

let rec doProp g c =
    match g=c with
    | true -> ()
    | false ->
        solvr()|>printfn "%s"
        doProp g (c+1)

doProp 3 0