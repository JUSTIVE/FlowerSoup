open System

let verifier (arr:array<int>) =
    if (arr.[2] = arr.[1])&&(arr.[1] = arr.[0]) then 2
    else
        let marr = arr|>Array.map (fun x -> Math.Pow(x|>float,2.0)|>int)
        if marr.[2] = marr.[1]+marr.[0] then 1
        else 0

Console.ReadLine().Split()
|>Array.map int
|>Array.sort
|>verifier
|>printfn "%d"