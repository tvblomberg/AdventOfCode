module ReactorReportEvaluatorTests

open AOC.Lib
open Xunit
open ReactorReportEvaluator

[<Fact>]
let ``removeAt 0 should remove the first element from the array`` () : unit =
    let actual = removeAt 0 [|1; 2; 3; 4; 5|]
    let expected = [|2; 3; 4; 5|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``removeAt -1 should return the entire array`` () : unit =
    let actual = removeAt -1 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 3; 4; 5|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``removeAt middle index should return the array without that index`` () : unit =
    let actual = removeAt 2 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 4; 5|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``removeAt end index should return the array without that index`` () : unit =
    let actual = removeAt 4 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 3; 4|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``removeAt bad index should return the entire array`` () : unit =
    let actual = removeAt 20 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 3; 4; 5;|]
    
    Assert.Equal<int array>(expected, actual)


(*
7 6 4 2 1: Safe because the levels are all decreasing by 1 or 2.
1 2 7 8 9: Unsafe because 2 7 is an increase of 5.
9 7 6 2 1: Unsafe because 6 2 is a decrease of 4.
1 3 2 4 5: Unsafe because 1 3 is increasing but 3 2 is decreasing.
8 6 4 4 1: Unsafe because 4 4 is neither an increase nor a decrease.
1 3 6 7 9: Safe because the levels are all increasing by 1, 2, or 3.
*)

[<Theory>]
[<InlineData("7 6 4 2 1", ReportStatus.Safe)>]
[<InlineData("1 2 7 8 9", ReportStatus.Unsafe)>]
[<InlineData("9 7 6 2 1", ReportStatus.Unsafe)>]
[<InlineData("1 3 2 4 5", ReportStatus.Unsafe)>]
[<InlineData("8 6 4 4 1", ReportStatus.Unsafe)>]
[<InlineData("1 3 6 7 9", ReportStatus.Safe)>]
let ``evaluateReportString should determine if report is safe or unsafe`` (report: string, expected: ReportStatus) : unit =
    let actual = evaluateReportString report
    Assert.Equal(expected, actual)

[<Fact>]
let ``safetyCount should report the amount of safe reports per report line in a string``() : unit =
    let reportString = [| "7 6 4 2 1"; "1 2 7 8 9"; "9 7 6 2 1"; "1 3 2 4 5"; "8 6 4 4 1"; "1 3 6 7 9" |]
    
    let actual = safetyCount reportString
    
    Assert.Equal(2, actual)
    
(*
7 6 4 2 1: Safe without removing any level.
1 2 7 8 9: Unsafe regardless of which level is removed.
9 7 6 2 1: Unsafe regardless of which level is removed.
1 3 2 4 5: Safe by removing the second level, 3.
8 6 4 4 1: Safe by removing the third level, 4.
1 3 6 7 9: Safe without removing any level.
*)    
[<Theory>]
[<InlineData("7 6 4 2 1", ReportStatus.Safe)>]
[<InlineData("1 2 7 8 9", ReportStatus.Unsafe)>]
[<InlineData("9 7 6 2 1", ReportStatus.Unsafe)>]
[<InlineData("1 3 2 4 5", ReportStatus.Safe)>]
[<InlineData("8 6 4 4 1", ReportStatus.Safe)>]
[<InlineData("1 3 6 7 9", ReportStatus.Safe)>]
[<InlineData("34 35 38 39 42 48", ReportStatus.Safe)>]
let ``evaluateReportStringWithSafetyDampener should determine if report is safe or unsafe with the dampener correcting for one index failure`` (report: string, expected: ReportStatus) : unit =
    let actual = evaluateReportStringWithSafetyDampener report
    Assert.Equal(expected, actual)
    
[<Fact>]
let ``safetyCountWithSafetyDampener should report the amount of safe reports including any dampener correction``() : unit =
    let reportString = [| "7 6 4 2 1"; "1 2 7 8 9"; "9 7 6 2 1"; "1 3 2 4 5"; "8 6 4 4 1"; "1 3 6 7 9" |]
    
    let actual = safetyCountWithSafetyDampener reportString
    
    Assert.Equal(4, actual)