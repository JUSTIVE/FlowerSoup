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
    ap
        |>Map.fold(fun s k v-> s&&v) true
    
let pengram s =
    if (checkpangram s) =true then "Y" else "N"
    |> printfn "%s"
let rec f ()=
    let s = Console.ReadLine()
    if s <> "*" then
        pengram s
        f()
f()