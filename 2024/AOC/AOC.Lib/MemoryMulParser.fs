namespace AOC.Lib

open System
open System.Text.RegularExpressions

module MemoryMulParser =
    let private parseMatchToTuple (m: Match) = Int32.Parse(m.Groups[1].Value), Int32.Parse(m.Groups[2].Value)
    
    let private calculateAndMultiply (input: (int * int) array) =
        input
        |> Array.map (fun (a, b) -> a * b)
        |> Array.sum
    
    let private sanitizeInput (input: string) =
        let pattern = @"don't\(\).*?(do\(\)|$)"
        
        Regex.Replace(input, pattern, "-")
    
    let parseMulToTupleArray (input: string) =
        let pattern = @"mul\((\d{1,3}),(\d{1,3})\)"
        
        Regex.Matches(input, pattern)
        |> Seq.map parseMatchToTuple
        |> Seq.toArray
        
    let parseAndMultiply input = input |> parseMulToTupleArray |> calculateAndMultiply
    
    let sanitizeParseAndMultiply input = input |> sanitizeInput |> parseAndMultiply
