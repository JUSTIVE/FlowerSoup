open System
let strRev (x:seq<char>) = 
    (String.Join("",x|>Seq.toList|>List.rev))|>int
Console.ReadLine().Split()
|>Array.map strRev
|>Array.reduce(fun x y ->Math.Max(x,y))
|>printfn"%d"