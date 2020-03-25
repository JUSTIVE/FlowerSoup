open System

let ins = Console.ReadLine().Split()|>Array.map int|>Array.sort
abs((ins.[0]+ins.[3])-(ins.[1]+ins.[2]))|>printf "%d"
