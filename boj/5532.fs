open System
let ins () = 
    let mutable a = Array.empty<int>
    for i in 0..4 do
        a<- Array.append a [|Console.ReadLine()|>int|]
    a
match ins() with
| [|q;w;e;r;t|] -> q - (Math.Max((Math.Ceiling((float e)/(float t))),(Math.Ceiling((float w)/(float r))))|>int)
| __ -> 0
|>printfn "%d"