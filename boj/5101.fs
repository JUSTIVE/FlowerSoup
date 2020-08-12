open System

type Result = 
    | Success of (int * int * int)
    | Failed

let rec printResult x =
    match x with
    | Success(x) -> 
        x |>successToString
    | Failed -> "X"
    |>printfn "%s"

and successToString (start,diff,goal) = 
    ((((goal - start)/diff)|>int) + 1)|>string

let DivisorChecker (x:Result) =
    match x with
    | Success(start,diff,goal)
        when ((goal - start)%diff) = 0 ->
            Success(start,diff,goal)
    | _ -> Failed

let NegativeChecker (x:Result) = 
    match x with
    | Success(start,diff,goal)
        when ((((goal - start)/diff)|>int) + 1) >= 1->
            Success(start,diff,goal)
    | _ -> Failed

let getInput () =
    Console.ReadLine().Split()
    |> Array.map int
    |> Array.toList

let rec prob ()=
    match getInput() with
    | [0;0;0] -> ignore
    | [start;diff;goal] ->
        Success(start,diff,goal)
        |> DivisorChecker
        |> NegativeChecker
        |> printResult
        prob ()
    | _ -> ignore

prob () |> ignore