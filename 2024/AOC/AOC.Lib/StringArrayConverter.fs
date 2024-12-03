namespace AOC.Lib

open System

module StringArrayConverter =
    let convertColumnsToArray = fun (a : string[]) ->
       let array1 = a |> Array.map (fun (x) -> Int32.Parse(x.Split("   ")[0]))
       let array2 = a |> Array.map (fun (x) -> Int32.Parse(x.Split("   ")[1]))
       
       (array1, array2)
       
    let convertLineToArray = fun (a : string) ->
        a.Split(" ")
        |> Array.map Int32.Parse
        
    let convertLinesToArrays = fun (a : string[]) ->
        a |> Array.map convertLineToArray