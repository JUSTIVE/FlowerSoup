open System
let rec leftpad g c=
    if c>=(g-1) then ignore
    else 
        printf " "
        leftpad g (c+1)

let rec doline g c=
    if c>=(g-1) then printf "*"|>ignore
    else
        printf "* "
        doline g (c+1)

let rec doStar g c=
    if c>=(g-1) then ignore
    else
        leftpad (g-c-1) 0|>ignore
        doline (c+1) 0
        printfn ""
        doStar g (c+1)

doStar ((Console.ReadLine()|>int)+1) 0|>ignore