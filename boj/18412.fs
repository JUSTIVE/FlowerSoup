open System
let [|n;a;b|] =
    Console
        .ReadLine()
        .Split()
    |>Array.map int
let ins = 
    Console
        .ReadLine()
ins.Substring(0,a-1)
+ String.Join("",(ins.Substring(a-1,b-(a-1))|>Seq.map string|>Array.ofSeq|>Array.rev))
+ ins.Substring(b,n-b)
|> printfn "%s"