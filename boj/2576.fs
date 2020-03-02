open System

let rec doProp s g c =
    if g=c then s
    else
        doProp ((Console.ReadLine()|>int)::s) g (c+1)
let c =
    doProp List.empty<int> 7 0
    |>List.filter(fun x->x%2=1)
if c|>List.length = 0 then
    printfn "-1"
else
    printfn "%d\n%d" (c|>List.sum) (c|>List.reduce(fun x y->Math.Min(x,y)))
