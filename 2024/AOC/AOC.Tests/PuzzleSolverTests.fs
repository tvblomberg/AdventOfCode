module AOC.Tests.PuzzleSolverTests

open AOC.Lib
open Xunit

[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 1, true, "Correct index")>]
[<InlineData("XMAS", 100, false, "Out of bounds")>]
let ``isMatchRight starting at an index should determine if the word matches right`` (word, index, isMatch, _) : unit =
    let testData = [| [|'M'; 'X'; 'M'; 'A'; 'S'; 'Z'|] |]
    
    let actual = PuzzleSolver.isMatchRight(testData, 0, index, word)
    
    Assert.Equal(isMatch, actual)
    
[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 4, true, "Correct index")>]
[<InlineData("XMAS", -1, false, "Out of bounds")>]
let ``isMatchLeft starting at an index should determine if the word matches left`` (word, index, isMatch, _) : unit =
    let testData = [| [|'M'; 'S'; 'A'; 'M'; 'X'; 'Z'|] |]
    
    let actual = PuzzleSolver.isMatchLeft(testData, 0, index, word)
    
    Assert.Equal(isMatch, actual)
    
    
[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 1, true, "Correct index")>]
[<InlineData("XMAS", 100, false, "Out of bounds")>]
let ``isMatchDown starting at an index should determine if the word matches down`` (word, index, isMatch, _) : unit =
    let testData = [|
        [|'M'|]
        [|'X'|]
        [|'M'|]
        [|'A'|]
        [|'S'|]
        [|'Z'|]
    |]
    
    let actual = PuzzleSolver.isMatchDown(testData, index, 0, word)
    
    Assert.Equal(isMatch, actual)
    
[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 4, true, "Correct index")>]
[<InlineData("XMAS", -1, false, "Out of bounds")>]
let ``isMatchUp starting at an index should determine if the word matches up`` (word, index, isMatch, _) : unit =
    let testData = [|
        [|'M'|]
        [|'S'|]
        [|'A'|]
        [|'M'|]
        [|'X'|]
        [|'Z'|]
    |]
    
    let actual = PuzzleSolver.isMatchUp(testData, index, 0, word)
    
    Assert.Equal(isMatch, actual)

[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 1, true, "Correct index")>]
[<InlineData("XMAS", 100, false, "Out of bounds")>]
let ``isMatchDownRightDiagonal starting at an index should determine if the word matches down/right`` (word, index, isMatch, _) : unit =
    let testData = [|
        [|'M'; 'X'; 'Y'; 'Y'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'M'; 'Y'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'Y'; 'A'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'Y'; 'Y'; 'S'; 'Z'|]
    |]
    
    let actual = PuzzleSolver.isMatchDownRightDiagonal(testData, 0, index, word)
    
    Assert.Equal(isMatch, actual)
    
[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 4, true, "Correct index")>]
[<InlineData("XMAS", 100, false, "Out of bounds")>]
let ``isMatchDownLeftDiagonal starting at an index should determine if the word matches down/left`` (word, index, isMatch, _) : unit =
    let testData = [|
        [|'M'; 'Y'; 'Y'; 'Y'; 'X'; 'Z'|];
        [|'M'; 'Y'; 'Y'; 'M'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'A'; 'Y'; 'Y'; 'Z'|];
        [|'M'; 'S'; 'Y'; 'Y'; 'Y'; 'Z'|]
    |]
    
    let actual = PuzzleSolver.isMatchDownLeftDiagonal(testData, 0, index, word)
    
    Assert.Equal(isMatch, actual)
    
[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 1, true, "Correct index")>]
[<InlineData("XMAS", 100, false, "Out of bounds")>]
let ``isMatchUpRightDiagonal starting at an index should determine if the word matches up/right`` (word, index, isMatch, _) : unit =
    let testData = [|
        [|'M'; 'Y'; 'Y'; 'Y'; 'S'; 'Z'|];
        [|'M'; 'Y'; 'Y'; 'A'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'M'; 'Y'; 'Y'; 'Z'|];
        [|'M'; 'X'; 'Y'; 'Y'; 'Y'; 'Z'|]
    |]
    
    let actual = PuzzleSolver.isMatchUpRightDiagonal(testData, 3, index, word)
    
    Assert.Equal(isMatch, actual)
    
[<Theory>]
[<InlineData("XMAS", 0, false, "Wrong index")>]
[<InlineData("XMAS", 4, true, "Correct index")>]
[<InlineData("XMAS", 100, false, "Out of bounds")>]
let ``isMatchUpLeftDiagonal starting at an index should determine if the word matches up/left`` (word, index, isMatch, _) : unit =
    let testData = [|
        [|'M'; 'S'; 'Y'; 'Y'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'A'; 'Y'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'Y'; 'M'; 'Y'; 'Z'|];
        [|'M'; 'Y'; 'Y'; 'Y'; 'X'; 'Z'|]
    |]
    
    let actual = PuzzleSolver.isMatchUpLeftDiagonal(testData, 3, index, word)
    
    Assert.Equal(isMatch, actual)
    
[<Fact>]
let ``solveForAllDirections should count all the matches and solve the puzzle`` () : unit =

    let testData = [|
        [| 'M'; 'M'; 'M'; 'S'; 'X'; 'X'; 'M'; 'A'; 'S'; 'M' |]
        [| 'M'; 'S'; 'A'; 'M'; 'X'; 'M'; 'S'; 'M'; 'S'; 'A' |]
        [| 'A'; 'M'; 'X'; 'S'; 'X'; 'M'; 'A'; 'A'; 'M'; 'M' |]
        [| 'M'; 'S'; 'A'; 'M'; 'A'; 'S'; 'M'; 'S'; 'M'; 'X' |]
        [| 'X'; 'M'; 'A'; 'S'; 'A'; 'M'; 'X'; 'A'; 'M'; 'M' |]
        [| 'X'; 'X'; 'A'; 'M'; 'M'; 'X'; 'X'; 'A'; 'M'; 'A' |]
        [| 'S'; 'M'; 'S'; 'M'; 'S'; 'A'; 'S'; 'X'; 'S'; 'S' |]
        [| 'S'; 'A'; 'X'; 'A'; 'M'; 'A'; 'S'; 'A'; 'A'; 'A' |]
        [| 'M'; 'A'; 'M'; 'M'; 'M'; 'X'; 'M'; 'M'; 'M'; 'M' |]
        [| 'M'; 'X'; 'M'; 'X'; 'A'; 'X'; 'M'; 'A'; 'S'; 'X' |]
    |]
    
    let actual = PuzzleSolver.solveForAllDirections(testData, "XMAS")
    
    Assert.Equal(18, actual)
    
[<Fact>]
let ``solveForX should count all X words and solve the puzzle`` () : unit =
    let testData = [|
        [| '.'; 'M'; '.'; 'S'; '.'; '.'; '.'; '.'; '.'; '.' |]
        [| '.'; '.'; 'A'; '.'; '.'; 'M'; 'S'; 'M'; 'S'; '.' |]
        [| '.'; 'M'; '.'; 'S'; '.'; 'M'; 'A'; 'A'; '.'; '.' |]
        [| '.'; '.'; 'A'; '.'; 'A'; 'S'; 'M'; 'S'; 'M'; '.' |]
        [| '.'; 'M'; '.'; 'S'; '.'; 'M'; '.'; '.'; '.'; '.' |]
        [| '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.' |]
        [| 'S'; '.'; 'S'; '.'; 'S'; '.'; 'S'; '.'; 'S'; '.' |]
        [| '.'; 'A'; '.'; 'A'; '.'; 'A'; '.'; 'A'; '.'; '.' |]
        [| 'M'; '.'; 'M'; '.'; 'M'; '.'; 'M'; '.'; 'M'; '.' |]
        [| '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.' |]
    |]
    
    let actual = PuzzleSolver.solveForX(testData)
    
    Assert.Equal(9, actual)