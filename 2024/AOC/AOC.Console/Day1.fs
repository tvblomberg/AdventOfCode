namespace AOC.Console

open AOC.Lib.LocationReconciliation
open AOC.Lib.Utils.StringArrayConverter

module Day1 =
    let run = fun (input: string[]) ->
        let a, b = convertColumnsToArray input
        let reconciliationResult = reconcile a b
        let similarityScore = calculateSimilarityScore a b

        printfn $"Reconciliation Result: %d{reconciliationResult}"
        printfn $"Similarity Score: %d{similarityScore}"