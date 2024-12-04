namespace AOC.Lib

open System
open System.Text.RegularExpressions

module MemoryMulParser =
    let private parseGroups (m: Match) = Int32.Parse(m.Groups[1].Value), Int32.Parse(m.Groups[2].Value)
    
    let private multipleTupleArray (input: (int * int) array) =
        input
        |> Array.map (fun (a, b) -> a * b)
        |> Array.sum
    
    let parse (input: string) =
        let pattern = @"mul\((\d{1,3}),(\d{1,3})\)"
        
        Regex.Matches(input, pattern)
        |> Seq.map parseGroups
        |> Seq.toArray
        
    let parseAndMultiply input = multipleTupleArray (parse input)
