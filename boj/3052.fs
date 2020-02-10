open System
let mutable ins = Array.empty<int>
for i in 0..9 do
    ins <- Array.append ins [|Console.ReadLine()|>int|]
ins
|>Array.map (fun x->x%42)
|>Array.distinct
|>Array.length
|>printfn "%d"