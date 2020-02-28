open System
Console.ReadLine()|>ignore
Console.ReadLine()
|>Seq.filter(fun x-> x='a'||x='i'||x='o'||x='u'||x='e')
|>Seq.length
|>printfn"%d"