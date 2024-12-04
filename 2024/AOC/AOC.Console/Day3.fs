namespace AOC.Console
open AOC.Lib

module Day3 =
    let run (input: string[]) : unit =
        let joinedStringArray = [| String.concat "" input |]
        let part1Result = joinedStringArray |> Array.map MemoryMulParser.parseAndMultiply |> Array.sum
        let part2Result = joinedStringArray |> Array.map MemoryMulParser.sanitizeParseAndMultiply |> Array.sum
        
        printfn $"Part1 Sum: %d{part1Result}"
        printfn $"Part2 Sum: %d{part2Result}"
    

