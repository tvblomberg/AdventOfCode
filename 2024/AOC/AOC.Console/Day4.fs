namespace AOC.Console
open AOC.Lib

module Day4 =
    let run (input: string[]) : unit =
        let charArray = input |> Array.map (fun x -> x.ToCharArray())
        let word = "XMAS"

        let part1Result = PuzzleSolver.solveForAllDirections(charArray, word)
        let part2Result = PuzzleSolver.solveForX(charArray)
        
        printfn $"Part1 Result: %d{part1Result}"
        printfn $"Part2 Result: %d{part2Result}"
    

