open System

let totsec = [|0;0;0;0|]|>Array.fold(fun a b-> a + (Console.ReadLine()|>int)) 0
printf "%d\n%d" (totsec/60) (totsec%60)
