open System

let validateDoomNum x = (x|>string).Contains "666"
([666..2666809]|>List.filter validateDoomNum).[(Console.ReadLine()|>int) - 1]|>printfn "%d"
 