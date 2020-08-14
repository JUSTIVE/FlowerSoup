open System

let widthMapper x =
    match x with
    | '1' -> 2
    | '0' -> 4
    | _ -> 3

let logic (x) =
    let len = x|>String.length
    (x
    |>Seq.toList
    |>List.map widthMapper
    |>List.sum) + 1 + len
    
let rec doProb () =
    match Console.ReadLine() with
    | "0" -> ()
    | x ->
        logic x
        |>printfn "%d"
        doProb()
doProb()