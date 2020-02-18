open System

let geti ()= 
    Console.ReadLine()|>int

let sum3 sa=
    (sa|>Array.reduce(fun x y -> x+y))-(sa|>Array.head)
    
match [|geti();geti();geti();geti()|],[|geti();geti()|] with
| (a,b) ->
    let sa = a|>Array.sort
    let sb = b|>Array.sortDescending|>Array.head
    printfn "%d" ((sum3 sa)+sb)
| __ -> failwith "unknown"