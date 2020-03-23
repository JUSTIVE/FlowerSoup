open System
            
let strRev α=let N=System.Globalization.StringInfo.GetTextElementEnumerator(α)
             List.unfold(fun n->if n then Some(N.GetTextElement(),N.MoveNext()) else None)(N.MoveNext())|>List.rev|>String.concat ""
    
let rec doProp () =
    let a = Console.ReadLine()
    if a = "0" then ()
    else
        printfn "%s" (if (a=strRev a) then "yes" else "no")
        doProp()

doProp()