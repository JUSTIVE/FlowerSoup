open System
open System.Numerics

printfn "%A" (Console
                  .ReadLine()
                  .Split()
              |>Array.map int64
              |>Array.reduce (fun x y-> x + y)|>bigint)