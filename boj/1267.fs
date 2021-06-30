open System

type Cost = (int * PricePlan)

and PricePlan =
    | Young
    | Min
    | Same

let PPFormat (pp: PricePlan) =
    match pp with
    | Young -> "Y"
    | Min -> "M"
    | Same -> "Y M"

let printCost ((v, pp): Cost) = printfn "%s %d" (PPFormat pp) v

let costFunc x c t = ((x / t) + 1) * c

let yFunc x = costFunc x 10 30
let mFunc x = costFunc x 15 60

let identify (x: int array) : Cost =
    let yP = x |> Array.map yFunc |> Array.sum
    let mP = x |> Array.map mFunc |> Array.sum

    match min yP mP with
    | y when yP < mP -> Cost(y, Young)
    | m when yP > mP -> Cost(m, Min)
    | s -> Cost(s, Same)

Console.ReadLine() |> ignore

Console.ReadLine().Split()
|> Array.map int
|> identify
|> printCost
