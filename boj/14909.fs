open System

Console.ReadLine()
    .Split()
|>Array.map int
|>Array.filter(fun x -> x>0)
|>Array.length
|>printf "%d"