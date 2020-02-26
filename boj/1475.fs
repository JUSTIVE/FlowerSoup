open System
let flip inc =
    if inc = '9' then '6'
    else inc
let a = Console.ReadLine()

a
|>Seq.fold(
      fun x y->
          match x|>Map.tryFind (flip y) with
          | Some v ->
                if y = '9' || y = '6' then 
                    x|>Map.add '6' (v+0.5)
                else
                    x|>Map.add y (v+1.0)
          | None ->
              if y = '9' || y = '6' then 
                    x|>Map.add '6' 0.5 
                else
                    x|>Map.add y 1.0
      )
      Map.empty<char,double>
|>Map.toSeq
|>Seq.fold(fun v (c,d)-> Math.Max(v,d)) 0.0
|>Math.Ceiling
|>int
|>printfn "%d"