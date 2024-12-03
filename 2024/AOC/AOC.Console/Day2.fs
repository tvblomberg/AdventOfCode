namespace AOC.Console

open AOC.Lib.ReactorReportEvaluator

module Day2 =
    let run (input: string[]) : unit =
        let safetyCount = safetyCount input
        let safetyCountWithDampener = safetyCountWithSafetyDampener input
        
        input
            |> Array.map (fun x -> printfn $"Report Details: %A{(x, evaluateReportStringWithSafetyDampener x)}") |> ignore
            
        printfn $"Safety count: %d{safetyCount}"
        printfn $"Safety count with dampener: %d{safetyCountWithDampener}"
        
    