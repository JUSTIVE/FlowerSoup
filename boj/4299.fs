open System

let condition a b = 
    if a < 0 || b < 0 then false
    else
        true

let ind = 
    match Console.ReadLine().Split()|>Array.map int with
    | [|a;b|]->
        let c = (a+b)/2
        let d =  a - c
        if(condition c d) && (a+b)%2=0 then
            printfn "%d %d" (Math.Max(c,d)|>int) (Math.Min(c,d)|>int)
        else
            printfn "-1"
    | _-> ()