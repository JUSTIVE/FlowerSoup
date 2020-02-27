open System

let rec doProp ins =
    if ins = "0 0" then ()
    else
        match ins.Split()|>Array.map int with
        | [|a;b|] when a>b
            ->"Yes"
        | __ ->"No"
        |>printfn "%s"
        doProp (Console.ReadLine())
        
doProp (Console.ReadLine())