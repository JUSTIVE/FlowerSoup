open System

let geti () =
    Console.ReadLine().Split()
    |>Array.map float
let calc i =
    match i with
    | [|a;b;c;d;e|]->
        [|a*350.34;b*230.90;c*190.55;d*125.30;e*180.90|]
        |>Array.fold (fun x y-> x + y) 0.0
    | __->failwith "f"

let rec dop g c =
    if c=g then ignore
    else
        printfn "$%.2f" (calc (geti()))
        dop g (c+1)
        
dop (Console.ReadLine()|>int) 0
|>ignore