open System
open System.Collections.Generic
type node (idIn:int)=
    static member doBfs(initialNode) =
        ignore
    static member nodeList = Array.empty<node>
    member public this.id = idIn
    member val link = List.empty<node> with get, set
    member this.addLink(id)=
        this.link <-  node.nodeList.[id]::this.link

[<EntryPoint>]
let main argv =
    let ins = Console.ReadLine().Split(' ')|>Array.map(int)
    
    for i in 0..ins.[1] do
        let edge = Console.ReadLine().Split(' ')|>Array.map(int)
        node.nodeList.[edge.[0]].addLink(edge.[1])
        
    node.doBfs(ins.[2])|>ignore
    0