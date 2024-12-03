namespace AOC.Lib


open AOC.Lib.Utils.ArrayUtils
open AOC.Lib.Utils.StringArrayConverter

module ReactorReportEvaluator =
    type ReportStatus =
        | Safe = 1
        | Unsafe = 2

    let private isWithinRange (a, b) = abs (a - b) <= 3
    let private isIncreasing (a, b) = b > a
    let private isDecreasing (a, b) = b < a

    let private isIncreasingOrDecreasingSafely pairs =
        (Array.forall isIncreasing pairs || Array.forall isDecreasing pairs) && Array.forall isWithinRange pairs

    let isReportSafe reportValues =
        reportValues
        |> Array.pairwise
        |> isIncreasingOrDecreasingSafely

    let private tryWithSafetyDampener (reportValues: int array) =
        if isReportSafe reportValues then true else
            
        let rec loop index =
            match index with
            | i when i = reportValues.Length -> false
            | i when isReportSafe (omitAt i reportValues) -> true
            | i -> loop (i + 1)
        loop 0
        
    let private evaluateReportWith evaluateFn report =
        report
        |> convertLineToArray
        |> evaluateFn
        |> function
            | true -> ReportStatus.Safe
            | false -> ReportStatus.Unsafe

    let evaluateReportString report = evaluateReportWith isReportSafe report

    let evaluateReportStringWithSafetyDampener report = evaluateReportWith tryWithSafetyDampener report

    let private countSafeReports evaluateFn reports =
        reports
        |> Array.map evaluateFn
        |> Array.filter ((=) ReportStatus.Safe)
        |> Array.length

    let safetyCount reports =
        countSafeReports evaluateReportString reports

    let safetyCountWithSafetyDampener reports =
        countSafeReports evaluateReportStringWithSafetyDampener reports
