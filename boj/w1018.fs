open System
type CheckBoard = List<List<int>>
type BoardType = WhiteStart|BlackStart



let rec initCheckBoard row rowState checkerBoard :CheckBoard=
    match rowState < row with
    | true ->
        initCheckBoard row (rowState+1) (cleanLine()::checkerBoard)
    | false -> checkerBoard

and cleanLine () =
    Console.ReadLine()
    |>Seq.map curVal
    |>Seq.toList

and curVal c =
    match c with
    | 'W' -> 0
    | __ -> 1


let shouldBe i ii boardType= 
    match ((ii%2)+(i%2))%2 with
    | 0 ->
        match boardType with
        | WhiteStart -> 0
        | BlackStart -> 1
    | 1 ->
        match boardType with
        | WhiteStart -> 1
        | BlackStart -> 0

let calcChecker (checkerboard:CheckBoard) boardType :int= 
    checkerboard
    |>List.mapi(
        fun i x->
            x
            |>List.mapi(
                fun ii y->
                    Math.Abs(
                        (shouldBe i ii boardType)
                        -
                        y
                    )
            )
            |>List.sum
        )
    |>List.sum
    
    


let valueAnalyzer (checkBoard:CheckBoard) :int=
    
    Math.Min((calcChecker checkBoard WhiteStart),(calcChecker checkBoard BlackStart))    

match Console.ReadLine().Split()|>Array.map int with
| [|row;col|] ->
    initCheckBoard row 0 List.empty
    |> valueAnalyzer
    |> printfn "%d"
| _ -> ()

