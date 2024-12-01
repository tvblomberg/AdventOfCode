namespace AOC.Lib

open System

module StringArrayToIntArray =
    let convert = fun (a : string[]) ->
       let array1 = a |> Array.map (fun (x) -> Int32.Parse(x.Split("   ")[0]))
       let array2 = a |> Array.map (fun (x) -> Int32.Parse(x.Split("   ")[1]))
       
       (array1, array2)