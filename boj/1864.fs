open System

let char2Int c =
    match c with
    | '-' -> 0
    | '\\' -> 1
    | '(' -> 2
    | '@' -> 3
    | '?' -> 4
    | '>' -> 5
    | '&' -> 6
    | '%' -> 7
    | '/' -> -1

let octalizer ins =
    ins
    |>Seq.rev
    |>Seq.map char2Int
    |>Seq.indexed
    |>Seq.map (fun (a,b)->(a|>float,b|>float))
    |>Seq.fold(fun x (a,b) -> x + (((8.0**a)*b)|>int)) 0
    
let rec doProp () =
    let ins = Console.ReadLine()
    if ins="#" then ()
    else
        octalizer ins|>printfn "%d"
        doProp()

doProp()