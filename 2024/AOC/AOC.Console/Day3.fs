namespace AOC.Console
open AOC.Lib

module Day3 =
    let run (input: string[]) : unit =
        let result = input |> Array.map MemoryMulParser.parseAndMultiply
        
        printfn $"Sum of all multiplications: %d{result |> Array.sum}"
    

