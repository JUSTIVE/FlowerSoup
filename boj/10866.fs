open System

type Deque = list<int>

type DequeCommand = 
    | Push_Front of int
    | Push_Back of int
    | Pop_Front
    | Pop_Back
    | Size
    | Empty
    | Front
    | Back

let parseInput (x:string) : DequeCommand =
    match x.Split() with
    | [|"push_front";a|] -> Push_Front(a|>int)
    | [|"push_back";a|] -> Push_Back(a|>int)
    | [|"pop_front"|] -> Pop_Front
    | [|"pop_back"|] -> Pop_Back
    | [|"size"|] -> Size
    | [|"empty"|] -> Empty
    | [|"front"|] -> Front
    | __ -> Back
    
let dequeAction state dequeCommand:Deque =
    match dequeCommand with
    | Push_Front(x) ->
        x::state
    | Push_Back(x)->
        x::(state|>List.rev)|>List.rev
    | Pop_Front ->
        match state with
        | h::t ->
            printfn "%d" h
            t
        | __->
            printfn "%d" -1
            state
    | Pop_Back ->
        match state|>List.rev with
        | h::t ->
            printfn "%d" h
            t|>List.rev
        | __->
            printfn "%d" -1
            state
    | Size ->
        printfn "%d" (state|>List.length)
        state
    | Empty ->
        match state with
        | h::t -> 0
        | __-> 1
        |>printfn "%d"
        state
    | Front ->
        match state with
        | h::t ->
            printfn "%d" h
            state
        | __ ->
            printfn "%d" -1
            state
    | Back ->
        match state|>List.rev with
        | h::t ->
            printfn "%d" h
            state
        | __ ->
            printfn "%d" -1
            state

let rec doProb T state=
    match T with
    | 0 -> ()
    | __->
        Console.ReadLine()
        |>parseInput
        |>dequeAction state
        |>doProb (T-1)
        

[<EntryPoint>]
let main argv = 
    let T = Console.ReadLine()|>int
    List.empty<int>
    |> doProb T
    0