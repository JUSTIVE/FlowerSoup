open System

let n_choose_k n k =
    let rec choose lo  =
        function
          |0 -> [[]]
          |i -> [for j=lo to (Array.length n)-1 do
                      for ks in choose (j+1) (i-1) do
                        yield n.[j] :: ks ]
    in choose 0  k

let [|n;v|] =
    Console.ReadLine().Split()|>Array.map int
let data = Console.ReadLine().Split()|>Array.map int 
let comb = n_choose_k data 3
v -
(comb
|>List.map(
    fun sl ->
        v-(sl|>List.reduce (+)))
|>List.filter(fun s-> s >=0)
|>List.sort
|>List.head) 
|>printf "%d"