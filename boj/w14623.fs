open System

let cald (a,b) (c,d) :bigint=
    b*d
let geti () :(bool*bigint) =
    Console.ReadLine()
    |>bigint.TryParse
printfn "%A" (cald (geti()) (geti()) )