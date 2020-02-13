open System
let rec init t i :Map<char,int> =
    if i > ['a'..'z'].Length-1 then t
    else init (t|>Map.add ['a'..'z'].[i] 0) (i+1)
let checkpangram s=
    let t = init Map.empty<char,int> 0
    let rec afs (m:Map<char,int>) (s:string) (i:int) =
        if i > (s|>Seq.length)-1 then m
        else
            let v =
                match (m|>Map.tryFind s.[i]) with
                | Some a -> a+1
                | __ -> 1
            afs (m|>Map.add s.[i] v) s (i+1)
    let q = afs t s 0
    let w =
        match q|>Map.tryFind (s.[0]) with
        | Some a -> a
        | __ -> 0
    q |> Map.fold(fun s k v-> Math.Min(s,v)) w

for i in 0..((Console.ReadLine()|>int)-1) do
    let u =
        Console.ReadLine()
        |>Seq.filter(fun x -> (x>='a'&&x<='z')||(x>='A'&&x<='Z'))
        |>Seq.map(fun x -> x|>Char.ToLower)
        |>String.Concat
    match u with
    | "" -> "Not a pangram"
    | ut ->
        match checkpangram <|ut with
        | 0-> "Not a pangram"
        | 1-> "Pangram!"
        | 2-> "Double pangram!!"
        | 3-> "Triple pangram!!!"
        | __-> ""
    |> printfn "Case %d: %s" (i+1)