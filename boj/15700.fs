open System
open System.Numerics

((Console.ReadLine().Split()
|>Array.map BigInteger.Parse
|>Array.reduce(fun a b -> a * b)) / 2I)
|>printfn "%A"