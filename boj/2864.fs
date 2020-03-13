open System

let sangC inc lamb =
    inc
    |>Seq.map lamb
    |>Seq.map(fun x->string x)
    |>Seq.fold(fun a b->a+b) ""
    |>int

let sangMax inc =
    sangC inc (fun x->if x = '5' then '6' else x)

let sangMin inc =
    sangC inc (fun x->if x = '6' then '5' else x)

let doCalcP ins l =
    ins
    |>Array.fold(fun a b -> a + (l b)) 0

let doProp ins =
    [|sangMin;sangMax|]
    |>Array.map(
        fun x -> 
            doCalcP ins x
            |>printf "%d ")

Console.ReadLine().Split()
|>doProp|>ignore
