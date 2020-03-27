open System
let value = Console.ReadLine()
let pre = value.[..(value.Length/2-1)]
let post = value.[(value.Length/2)..]
let ii v =
   v|>Seq.map int|>Seq.reduce (+)  
(match ii pre = ii post with
|true->   "LUCKY"
|false->  "READY")
|>printf "%s"