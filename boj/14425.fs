open System

let [|dictlen;searchlen|] =
    Console.ReadLine().Split()
    |>Array.map int

let rec initSet s g c =
    if g = c then s
    else
        initSet (s|>Set.add (Console.ReadLine())) g (c+1)
  
let rec searcher g c v s=
    if g = c then v
    else
        searcher g (c+1) (v + (if s|>Set.contains (Console.ReadLine())then 1 else 0)) s
        
initSet Set.empty<String> dictlen 0
|>searcher searchlen 0 0
|>printf "%d"
        