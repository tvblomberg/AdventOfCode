namespace AOC.Console

open AOC.Lib

module Day1 =
    let run = fun (input: string[]) ->
        let a, b = StringArrayConverter.convertColumnsToArray input
        let reconciliationResult = LocationReconciliation.reconcile a b
        let similarityScore = LocationReconciliation.calculateSimilarityScore a b

        printfn $"Reconciliation Result: %d{reconciliationResult}"
        printfn $"Similarity Score: %d{similarityScore}"