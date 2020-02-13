open System
let a =Console.ReadLine()|>int
let b =Console.ReadLine()|>int
let c =Console.ReadLine()|>int
match a,b,c with
| a,b,c when a+b+c <>180 -> "Error"
| a,b,c when a=60&&b=60&&c=60 -> "Equilateral"
| a,b,c when a=b||b=c||a=c -> "Isosceles"
| __ -> "Scalene"
|>printfn "%s"