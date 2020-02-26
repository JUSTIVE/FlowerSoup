open System

let rec doFac v =
    if v = 0I then 1I
    else
        v*(doFac (v-1I))

let doComb n r=
    (doFac n)/(doFac r *(doFac (n-r)))

let rec doProp g c =
    if g=c then ()
    else
        let [|a;b|] = Console.ReadLine().Split()|>Array.map bigint.Parse
        match (a,b) with
        | (a,b) when a>=b ->
            doComb a b
        | (a,b) when a<b ->
            doComb b a
        | __->failwith "unexpected"
        |> printfn "%A"
        doProp g (c+1)
        
doProp (Console.ReadLine()|>int) 0