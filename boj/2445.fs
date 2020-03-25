open System

let rec printer code g c =
    if g=c then ()
    else
       printf "%s" code
       printer code g (c+1)
       
let printline c value=
    printer "*" c 0
    printer " " (abs((value-c)*2)) 0
    printer "*" c 0
    printfn ""

let rec starPlatinum c actor value initvalue=
    if c = value then initvalue
    else
        printline (c+1) initvalue
        starPlatinum (c+actor) actor value initvalue

let initvalue =
    Console.ReadLine()
    |>int 
 

starPlatinum ((starPlatinum 0 1 initvalue initvalue)-2) -1 -1 initvalue|>ignore

