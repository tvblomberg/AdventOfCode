namespace AOC.Lib

module ReactorReportEvaluator =
    type ReportStatus =
        | Safe = 1
        | Unsafe = 2

    let removeAt index (arr: 'a array) : 'a array =
        if index < 0 || index >= arr.Length then arr
        else
            [| yield! arr[0 .. index - 1]
               yield! arr[index + 1 ..] |]

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
        let rec loop index =
            match index with
            | i when i > reportValues.Length - 1 -> false
            | i when isReportSafe (removeAt i reportValues) -> true
            | i -> loop (i + 1)
        loop -1

    let evaluateReportString report =
        report
        |> StringArrayConverter.convertLineToArray
        |> isReportSafe
        |> function
            | true -> ReportStatus.Safe
            | false -> ReportStatus.Unsafe

    let evaluateReportStringWithSafetyDampener report =
        report
        |> StringArrayConverter.convertLineToArray
        |> tryWithSafetyDampener
        |> function
            | true -> ReportStatus.Safe
            | false -> ReportStatus.Unsafe

    let private countSafeReports evaluateFn reports =
        reports
        |> Array.map evaluateFn
        |> Array.filter ((=) ReportStatus.Safe)
        |> Array.length

    let safetyCount reports =
        countSafeReports evaluateReportString reports

    let safetyCountWithSafetyDampener reports =
        countSafeReports evaluateReportStringWithSafetyDampener reports
