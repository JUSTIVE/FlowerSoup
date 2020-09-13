open System

let inValue = Console.ReadLine()
let subSeq s e i = i|> Seq.skip s |> Seq.take e 
let cS2S i n x = (subSeq i n x) |> Seq.fold(fun s t-> s+(t|>Char.ToString)) ""
let split x i = ((cS2S 0 i x),cS2S i ((x|>String.length) - i) x)

let transformer x=
        x
        |>Seq.map (fun x ->(x|>int) - 48)
        |>Seq.fold (fun s x -> s * x) 1

let matcher (f,l) = transformer f = transformer l

let verifyEugeneNum x= 
    let y = x|>Seq.mapi(fun i a -> split x i)
    
    (subSeq 1 ((y|>Seq.length) - 1)  y)
    |>Seq.fold(fun s t -> s || (matcher t)) false

match verifyEugeneNum inValue with
| true-> "YES"
| __-> "NO"
|>printfn "%s"