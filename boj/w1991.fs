open System

type Node = {value:string; left:Node option; right:Node option}


let initNode value left right=
    {value=value;left=left;right=right}
    
let addToTree tree node :Node=
    ignore
    
let rec initTree (s:Node) (g:int) (c:int) =
    if g=c then s
    else
        match Console.ReadLine().Split() with
        | [|a;b;d|] ->
            
            initTree (initNode a ((initTree())|>Some) ((initNode d None None)|>Some)) g (c+1)
            
                
        | __-> failwith ""
        
        

let rec preorder root =
    printf "%s" root.value
    match root.left with
    | Some a ->
        preorder a
    | None ->
        match root.right with
        | Some a ->
            preorder a
        | None ->
            ()
            
let rec inorder root =
    match root.left with
    | Some a ->
        inorder a
    | None ->
        printf "%s" root.value
        match root.right with
        | Some a ->
            inorder a
        | None ->
            ()

let rec postorder root =
    match root.left with
    | Some a ->
        postorder a
    | None ->
        match root.right with
        | Some a ->
            postorder a
        | None ->
            printf "%s" root.value
            ()
    

let traverse root =
    preorder root|>ignore
    inorder root|>ignore
    postorder root|>ignore
    ()
    

initTree (initNode "." None None) (Console.ReadLine()|>int) 0
|>traverse