open System

let metaph ins = 
    ins
    |>Seq.mapi(
        fun x y->
            (x,
                match y with
                | ' '-> 0
                | __ -> (int __) - (int 'A') + 1))
let rec doProp ins = 
    if ins = "#" then ()
    else
        ins
        |>metaph
        |>Seq.fold (fun a (b,c)-> a+(b+1)*c) 0
        |>printfn "%d"
        doProp (Console.ReadLine())
doProp (Console.ReadLine())