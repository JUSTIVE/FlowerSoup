open System
printfn "%d" ([|1;2;3;4;5;4;3;2|].[(((Console.ReadLine()|>int) - 1) % 8)])