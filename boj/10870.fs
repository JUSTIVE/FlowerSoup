open System
let fib = [0;1]
let ap l (d:int) =
    List.rev (d::List.rev l)
let rec dofib (l:list<int>) (c:int) :list<int> =
    if c > 20 then l
    else dofib (ap l (l.[c-1]+l.[c-2])) (c+1)
printfn "%d" (dofib fib 2).[(Console.ReadLine()|>int)]