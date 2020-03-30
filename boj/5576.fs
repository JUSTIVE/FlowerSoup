open System
let rec read10 s g =
    if g = 10
    then
        s
        |>List.sortDescending
        |>List.take 3
        |>List.reduce (+)
    else
        read10 ((Console.ReadLine()|>int)::s) (g+1)
        

printfn "%d %d" (read10 List.empty<int> 0) (read10 List.empty<int> 0)        
