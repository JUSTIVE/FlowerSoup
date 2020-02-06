open System
     let gW:int =
         let ins =
             Console
                 .ReadLine()
                 .Trim()
         if ins = "" then  0 else ins.Split(' ').Length    
     
     [<EntryPoint>]
     let main argv =
         printfn "%A" gW
         0