open System
open System.IO
open AOC.Lib

let filePath = Environment.GetCommandLineArgs()[1]

let readFile (filePath: string) : string[] =
    File.ReadAllLines(filePath)

// Usage
let lines = readFile filePath

let a, b = StringArrayToIntArray.convert lines

let reconciliationResult = LocationReconciliation.reconcile a b
let similarityScore = LocationReconciliation.calculateSimilarityScore a b


printfn $"Reconciliation Result: %d{reconciliationResult}"
printfn $"Similarity Score: %d{similarityScore}"