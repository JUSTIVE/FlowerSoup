open System

let rec doProp ins =
    if ins = "END" then ()
    else
        printfn "%s" (ins|>Seq.rev|>String.Concat)
        doProp (Console.ReadLine())
        
doProp (Console.ReadLine())