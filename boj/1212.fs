open System

let oct2b c=
    match c with
    | '0' -> "000"
    | '1' -> "001"
    | '2' -> "010"
    | '3' -> "011"
    | '4' -> "100"
    | '5' -> "101"
    | '6' -> "110"
    | '7' -> "111"
    

let foct2b c=
    match c with
    | '0' -> ""
    | '1' -> "1"
    | '2' -> "10"
    | '3' -> "11"
    | '4' -> "100"
    | '5' -> "101"
    | '6' -> "110"
    | '7' -> "111"
    |>printf"%s"

match Console.ReadLine()|>Seq.toList with
|h::t ->
    if h = '0' then printf "0"
    else
        h|>foct2b
        String.Join("",t|>List.map oct2b)|>printf"%s"

|>ignore