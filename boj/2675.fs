open System
     [<EntryPoint>]
     let main argv =
         for i in 0..(Console.ReadLine()|>int)-1 do
            let ins = Console.ReadLine().Split(' ')
            for j in 0..ins.[1].Length-1 do
                for k in 0..(ins.[0]|>int)-1 do
                    printf "%c" ins.[1].[j]
                printfn ""
            ignore
         0