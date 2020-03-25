open System

[|0;0;0;0;0|]|>Array.fold(fun a b-> a + (Console.ReadLine()|>int)) 0
|>printf "%d"
