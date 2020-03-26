open System


let rec doProp s g (i:string)=
    if i.Length = g then s
    else
        doProp (i.[g..]::s) (g+1) i 

let p = Console.ReadLine()
doProp List.empty 0 p
|>List.sort
|>List.iter(printfn "%s")
