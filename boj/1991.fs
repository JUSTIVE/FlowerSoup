open System

type Node = {value:string; left:Node option; right:Node option}

let initNode value left right=
    {value=value;left=left;right=right}

let stringFilter s =
    match s with
    | "." -> None
    | __ -> Some __
    
let rec initMap m g c =
    if g=c then m
    else
        match Console.ReadLine().Split() with
        | [|a;b;d|] ->
            initMap 
                (m|>Map.add a (stringFilter b,stringFilter d))
                g
                (c+1)
        | __->failwith ""

let rec initTree m key =
    match m|>Map.find key with
    | b, c -> 
         initNode 
            key
            (genSubTree b m)
            (genSubTree c m)
and genSubTree b m=
    match b with
    | Some a -> Some(initTree m a)
    | None -> None

let rec preorder root =
    printf "%s" root.value
    match root.left with
    | Some a -> preorder a
    | None -> ()
    preorderInner root     
and preorderInner root= 
    match root.right with
    | Some a -> preorder a
    | None -> ()    

let rec inorder root =
    match root.left with
    | Some a -> inorder a
    | None -> ()
    inorderInner root

and inorderInner root =
    printf "%s" root.value
    match root.right with
    | Some a ->inorder a
    | None ->()

let rec postorder root =
    match root.left with
    | Some a ->postorder a
    | None ->()
    postorderInner root
and postorderInner root = 
    match root.right with
    | Some a ->postorder a
    | None ->()
    printf "%s" root.value

let runner actionFunction =
    actionFunction
    printfn ""

let traverse root =
    runner (preorder root)
    runner (inorder root)
    runner (postorder root)

initTree
    (initMap 
        Map.empty<string,string option*string option>
        (Console.ReadLine()|>int)
        0)
    "A" 
|>traverse