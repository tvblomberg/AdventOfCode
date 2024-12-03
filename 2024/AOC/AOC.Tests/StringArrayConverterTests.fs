module StringArrayConverterTests

open AOC.Lib.Utils.StringArrayConverter
open Xunit

[<Fact>]
let ``convertColumnsToArray should split string array into two lists`` () : unit =
    let testData = [|"3   4"; "4   3"; "2   5"; "1   3"; "3   9"; "3   3"|]
    let expectedArray1 = [|3; 4; 2; 1; 3; 3|]
    let expectedArray2 = [|4; 3; 5; 3; 9; 3|]
    
    let actual = convertColumnsToArray testData
    Assert.Equal((expectedArray1, expectedArray2), actual)
    
[<Fact>]
let ``convertLineToArray should split the string line into an array of integers`` () : unit =
    let testLine = "3 4 2 1 3 3"
    let expectedArray = [|3; 4; 2; 1; 3; 3|]
    
    let actual = convertLineToArray testLine
    
    Assert.Equal<int array>(expectedArray, actual)
    
[<Fact>]
let ``convertLinesToArrays should split the string lines into an arrays of integers`` () : unit =
    let testLine1 = "3 4 2 1 3 3"
    let testLine2 = "4 3 5 3 9 3"
    let expectedArray1 = [|3; 4; 2; 1; 3; 3|]
    let expectedArray2 = [|4; 3; 5; 3; 9; 3|]
    
    let actual = convertLinesToArrays [|testLine1; testLine2|]
   
    Assert.Equal<int array array>([|expectedArray1; expectedArray2|], actual)