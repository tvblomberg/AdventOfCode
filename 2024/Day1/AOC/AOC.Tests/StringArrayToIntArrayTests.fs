module AOC.Tests.StringArrayToIntArrayTests

open AOC.Lib
open Xunit

[<Fact>]
let ``Should split string array into two lists`` () : unit =
    let testData = [|"3 4"; "4 3"; "2 5"; "1 3"; "3 9"; "3 3"|]
    let expectedArray1 = [|3; 4; 2; 1; 3; 3|]
    let expectedArray2 = [|4; 3; 5; 3; 9; 3|]
    
    let actual = StringArrayToIntArray.convert [|"3 4"; "4 3"; "2 5"; "1 3"; "3 9"; "3 3"|]
    Assert.Equal((expectedArray1, expectedArray2), actual)