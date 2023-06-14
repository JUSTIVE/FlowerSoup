open System
open System.IO
open FSharp.Core

let rec parseToChunk (state: list<list<int>>) (args: list<string>) =
    match args with
    | "" :: t1 -> parseToChunk ([] :: state) t1
    | h1 :: t1 -> parseWithState state (Int32.Parse h1) t1
    | __ -> state

and parseWithState state cur restArgs =
    parseToChunk
        (match state with
         | h :: t -> ((cur :: h) :: t)
         | __ -> [ [ cur ] ])
        restArgs

let main (args: array<string>) =
    args
    |> Array.toList
    |> parseToChunk [ [] ]
    |> List.map List.sum
    |> List.sortDescending
    |> List.take 3
    |> List.sum

Path.Combine [| __SOURCE_DIRECTORY__; "22d1.txt" |]
|> File.ReadAllLines
|> main
|> Console.WriteLine
