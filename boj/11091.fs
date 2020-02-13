open System
let rec init t i :Map<char,bool> =
    if i > ['a'..'z'].Length-1 then t
    else init (t|>Map.add ['a'..'z'].[i] false) (i+1)
let checkpangram s=
    let mutable t = init Map.empty<char,bool> 0
    let ap = s
            |>Seq.map(fun x -> x|>Char.ToLower)
            |>Seq.filter(fun x -> x>='a'&&x<='z')
            |>Seq.map(fun x -> (x,true))
            |>Map.ofSeq
            |>Map.fold(fun s k v-> Map.add k v s) t
    (
     ap
        |>Map.fold(fun s k v-> s&&v) true,
     ap
        |>Map.toSeq
        |>Seq.fold
        (fun s (x,y) -> if y=false then s + string x else s)
        "")

for i in 0..((Console.ReadLine()|>int)-1) do
    match checkpangram <|Console.ReadLine() with
    | (true,"")->
        "pangram"
    | (false,a)->
        "missing " + a
    | __-> ""+string __
    |> printfn "%s"