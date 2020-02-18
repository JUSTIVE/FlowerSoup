open System
match Console.ReadLine().Split()|>Array.map int with
| [|a;b;c|] ->
    let x = Math.Sqrt(Math.Pow(float a,2.0)*(Math.Pow(float b,2.0)/((Math.Pow(float b,2.0)+(Math.Pow(float c,2.0))))))
    printfn "%d %d" (x|>int) (Math.Floor((float x)/(float b)*(float c))|>int)
| __ -> failwith "unknown"
