open System
open System.Globalization

[<EntryPoint>]
let main argv =
    printfn "%d" ((Console.ReadLine(),NumberStyles.HexNumber) |> Int32.Parse)  
    0