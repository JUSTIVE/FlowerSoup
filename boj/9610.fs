open System

let gMp m k =
    match m|>Map.tryFind k with
    | Some a -> a + 1
    | None -> 1

let acMp m k = 
    m|>Map.add k (gMp m k)

let geti ()=
    Console.ReadLine().Split()
    |>Array.map int

let i2t ()=
    match geti() with
    | [|a;b|] -> (a,b)
    | __ -> (0,0)

let rec doProp s g c=
    if c=g then s
    else
        let k = 
            match i2t() with
            | (a,b) ->
                if a=0||b=0 then "AXIS"
                else if a>0&&b>0 then "Q1"
                else if a>0&&b<0 then "Q4"
                else if a<0&&b>0 then "Q2"
                else "Q3"
        doProp (acMp s k) g (c+1)

let dop m x =
    match m|>Map.tryFind x with
    | Some v -> printfn "%s: %d" x v
    | None -> printfn "%s: 0" x
    
let printer m =
    [|"Q1";"Q2";"Q3";"Q4";"AXIS"|]
    |>Array.map (dop m)
      
doProp Map.empty<string,int> (Console.ReadLine()|>int) 0
|>printer
|>ignore