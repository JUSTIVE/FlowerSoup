open System
let numofX lis g =
    (lis|>Array.fold(fun x y -> if y = g then x+1 else x) 0)    
let ins = 
    Console.ReadLine().Split()
    |>Array.map int
if numofX ins 1 > numofX ins 2 then 1 else 2
|>printfn "%d" 