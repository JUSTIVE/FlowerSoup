open System
open System.Numerics

let rec bigIntToList x = 
    sprintf "%A" x
    |> Seq.toList
    |> List.rev
    |> List.map(charToInt)

and charToInt x =
    (int x) - 48

let rec carriageResolve c r x= 
    match x with
    | h::t->
        carriageResolve (carriageResolveInner h c) (appender h c r) t
    | _ -> c::r

and appender current carriage rlist = ((current+carriage)%2)::rlist

and carriageResolveInner current carriage = 
    ((current+carriage) >= 2)|>Convert.ToInt32

let listCharToInt (x:int list) =
    x
    |> List.map(string)
    |> List.reduce(fun a b -> a + b)
    |> BigInteger.Parse

System.Numerics.BigInteger.Parse(Console.ReadLine()) * 10001I
|> bigIntToList
|> carriageResolve 0 []
|> listCharToInt
|> printfn "%A"