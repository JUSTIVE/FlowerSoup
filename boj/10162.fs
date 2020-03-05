open System

let divs div (s,inc)=
    ((s + ((inc/div)|>string))+" ",(inc%div))

let doProp ins =
    match divs 300 ("",ins)|>divs 60|>divs 10 with
    | (a,b) when b=0 -> a
    | __-> "-1"
    |>printfn "%s"
    
doProp (Console.ReadLine()|>int)