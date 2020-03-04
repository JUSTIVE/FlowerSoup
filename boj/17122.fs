open System
let converter a =
    match a|>Seq.item 0 with
    | x-> (int (x) - (int 'A') + 1)
        + (((a|>Seq.item 1|>int)-48)-1)*8

let isBlack ins =
    ((ins%2)+(((ins-1)/8)%2))%2 = 1

let matcher s=
    match s with
    |[|a;b|] ->
        if isBlack (b|>int) = isBlack (converter a)
        then Some "YES"
        else Some "NO"
    |__->None

let rec doProp g c =
    if g = c then ()
    else 
        match matcher (Console.ReadLine().Split()) with
        | Some s -> printfn "%s" s
        | None -> ()
        doProp g (c+1)

doProp (Console.ReadLine()|>int) 0
