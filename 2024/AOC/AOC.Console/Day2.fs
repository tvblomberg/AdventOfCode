namespace AOC.Console

open AOC.Lib

module Day2 =
    let run (input: string[]) : unit =
        let safetyCount = ReactorReportEvaluator.safetyCount input
        let safetyCountWithDampener = ReactorReportEvaluator.safetyCountWithSafetyDampener input
        
        input
            |> Array.map (fun x -> printfn $"Report Details: %A{(x, ReactorReportEvaluator.evaluateReportStringWithSafetyDampener x)}") |> ignore
            
        printfn $"Safety count: %d{safetyCount}"
        printfn $"Safety count with dampener: %d{safetyCountWithDampener}"
        
    