open System

let mutable s = Map.empty<int,bool>
for i in 1..30 do
    s <- s|>Map.add i false
for i in 0..27 do
    s <- s|>Map.add (Console.ReadLine()|>int) true
for i in s do
    match i with
    | KeyValue(a,b) when b = false ->
        printfn "%d" a
    |__-> ()