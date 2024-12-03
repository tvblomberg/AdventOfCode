namespace AOC.Lib

module LocationReconciliation =
    let reconcile = fun (a : int[]) (b : int[]) ->
        let sortedA = Array.sort a
        let sortedB = Array.sort b
        
        Array.zip sortedA sortedB
        |> Array.map (fun (x, y) -> abs(x - y))
        |> Array.sum
        
    let numCount = fun (num: int, numArray: int[]) ->
        numArray
        |> Array.filter (fun x -> x = num)
        |> Array.length
        
    let calculateSimilarityScore = fun (a : int[]) (b : int[]) ->
        a
        |> Array.map (fun x -> x * numCount(x, b))
        |> Array.sum