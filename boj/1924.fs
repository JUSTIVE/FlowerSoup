open System

match Console.ReadLine().Split()|>Array.map int with
| [|a;b|] ->
    match (DateTime.TryParse(sprintf "%d/%d/2007" a b)) with
    | (a:bool,b:DateTime)->
        b.DayOfWeek
            .ToString()
            .ToUpper()
            .Substring(0,3)
| __ -> failwith "f"
|>printfn "%s"