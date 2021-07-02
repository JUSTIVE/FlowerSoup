open System

let sangC inc lamb =
    inc
    |> Seq.map lamb
    |> Seq.map (string)
    |> Seq.fold (+) ""
    |> int

let dt a b (x: char) =
    match x = a with
    | true -> b
    | __ -> x

let sangMax inc = sangC inc (dt '5' '6')

let sangMin inc = sangC inc (dt '6' '5')

let doCalcP ins l =
    ins |> Array.fold (fun a b -> a + (l b)) 0

let doProp ins =
    [| sangMin; sangMax |]
    |> Array.map (fun x -> doCalcP ins x |> printf "%d ")

Console.ReadLine().Split() |> doProp |> ignore
