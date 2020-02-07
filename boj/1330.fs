open System
     [<EntryPoint>]
     let main argv =
         printfn "%s" (match Console.ReadLine().Split()|>Array.map int with
            | [|a;b|] when (a > b) ->
                ">"
            | [|a;b|] when a = b ->
                "=="
            |__ ->
                "<")   
         0