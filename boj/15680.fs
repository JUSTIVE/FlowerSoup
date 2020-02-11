open System
match Console.ReadLine()|>int with
| 0 -> "YONSEI"
| __-> "Leading the Way to the Future"
|> printfn "%s"