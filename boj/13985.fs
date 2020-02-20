open System

let v = Console.ReadLine().Split()
match ((v.[0]|>int) + (v.[2]|>int)) = (v.[4]|>int) with
| true -> "YES"
| false -> "NO"
|>printfn "%s"