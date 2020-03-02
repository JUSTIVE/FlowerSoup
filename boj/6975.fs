open System

let rec getDivisor divisor target (inx:int) =
    if inx=target then divisor
    else
        getDivisor
            (if target%inx = 0 then divisor|>List.append [inx] else divisor)
            target
            (inx + 1)

let doAction inN =
    let sumv = (getDivisor List.empty<int> inN 1)|>List.sum 
    match sumv with
    | x when x = inN -> "a perfect"
    | x when x > inN -> "an abundant"
    | __-> "a deficient"
    |>sprintf "%d is %s number." inN
    
                                                    
let rec doProp g c =
    if g=c then ()
    else
        Console.ReadLine()|>int
        |>doAction
        |>printfn "%s\n"
        doProp g (c+1)

doProp (Console.ReadLine()|>int) 0