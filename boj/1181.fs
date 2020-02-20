open System
let rec doA s g c=
    if c=g then s
    else doA (s|>Set.add (Console.ReadLine())) g (c+1)
    
doA Set.empty<string> (Console.ReadLine()|>int) 0
|>Set.toList
|>List.sortBy (fun x -> x.Length)
|>List.map (fun x -> printfn "%s" x)
|>ignore