open System
let fib = [0I;1I]
let ap l d =
    List.rev (d::List.rev l)
let rec dofib l c =
    if c > 91I then l
    else dofib (ap l (l.[(c-1I|>int)]+l.[(c-2I|>int)])) (c+1I)
printfn "%A" (dofib fib 2I).[(Console.ReadLine()|>int)]