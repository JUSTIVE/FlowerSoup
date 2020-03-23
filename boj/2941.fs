open System

let printer ins =
    printf "%d" ins
let doProp (ins:string) =
    ins
        .Replace("c=","č")
        .Replace("c-","ć")
        .Replace("dz=","ž")
        .Replace("d-","đ")
        .Replace("lj","ㄱ")
        .Replace("nj","ㄴ")
        .Replace("s=","š")
        .Replace("z=","ž")
        .Length

Console.ReadLine()
|>doProp
|>printer

//let tester ins v= 
//    doProp ins = v |> printfn "%A"
//tester "ljes=njak" 6
//tester "ddz=z=" 3
//tester "nljj" 3
//tester "c=c=" 2