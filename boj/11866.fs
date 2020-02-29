open System

let getJosephusIndex k cIndex listLen =
    (cIndex + k) % (listLen + if cIndex + k < listLen then 1 else 0)

let rec Josephus k cIndex (inList:int[]) conS =
    if inList|>Array.length = 0 then conS
    else
       let JosephusIndex = getJosephusIndex k cIndex (inList|>Array.length)
       ((conS + (inList.[JosephusIndex]|>string)) +
           match inList|>Array.length with
           | 1 -> ""
           | __ ->", ")
       |>Josephus k JosephusIndex (inList|>Array.filter(fun x-> x<>inList.[JosephusIndex])) 

let printJosephus k cIndex inList =
    printf "<%s>" (Josephus k cIndex inList "")

match Console.ReadLine().Split()|>Array.map int with
| [|n;k|] -> printJosephus (k-1) 0 (Array.init n (fun x->x+1))
| __-> failwith ""