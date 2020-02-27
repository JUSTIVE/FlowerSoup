open System

let rec dofib (s:seq<int>) g=
    if g=(s|>Seq.length) then s
    else
       let newVal = ((s|>Seq.rev|>Seq.item 0)+(s|>Seq.rev|>Seq.item 1))
       dofib (s|>Seq.rev|>Seq.append [newVal]|>Seq.rev) g
       
let a,b = dofib [1;0;1;1] 46, dofib [0;1;1] 46
let inx = Console.ReadLine()|>int
printfn "%d %d" (a|>Seq.item inx) (b|>Seq.item inx) 