open System
            
let strRev α=
    let N=System.Globalization.StringInfo.GetTextElementEnumerator(α)
    List.unfold(fun n->if n then Some(N.GetTextElement(),N.MoveNext()) else None)(N.MoveNext())
    |>List.rev
    |>String.concat ""

let palindrome a=
    match a=strRev a with
    | true -> "yes"
    | false -> "no"

let rec doProp () =
    let a = Console.ReadLine()
    match a with
    | x when x="0" -> ()
    | __ ->
        printfn "%s" palindrome a
        doProp()

doProp()