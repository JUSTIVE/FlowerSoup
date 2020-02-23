open System
let alphInx =
    [|0;0;0;1;1;1;2;2;2;3;3;3;4;4;4;5;5;5;5;6;6;6;7;7;7;7;|]
    |>Array.map (fun x -> x+3)
    
Console.ReadLine()
|>Seq.map(fun c -> alphInx.[(int c) - (int 'A')])
|>Seq.fold(fun x y -> x + y) 0
|>printfn "%d"