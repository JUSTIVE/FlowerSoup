open System

let get10pow n =
    Math.Pow(10.0,float n)
    
let chk10pow i n =
    float i>=(get10pow n)

let doR (i:float) (n:int) =
    Math.Round(float (i/(get10pow n)))*(get10pow n)

let rec doA i c=
    if chk10pow i c then
        doA (doR i c) (c+1)
    else i

doA (Console.ReadLine()|>float) 0
|>int
|>printfn "%d"