open System
let rec paintBlank g c =
    if g-1 = c then ()
    else 
        printf " "
        paintBlank g (c+1)
let rec fillBlank g c=
    if g-2=c then ()
    else
        printf " "
        fillBlank g (c+1)
let paintRow g c =
    if g = 0 then
        printf "*"
    else
        printf "*"
        fillBlank (2*g+1) 0
        printf "*"
let rec paintBottom g c=
    if g=c then ()
    else
        printf "*"
        paintBottom g (c+1)
let rec paintS c g=
    if g-2 < c then paintBottom (g*2-1) 0
    else
        paintBlank (g-c) 0
        paintRow c 0
        printfn ""
        paintS (c+1) g
paintS 0 (Console.ReadLine()|>int)