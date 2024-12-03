module LocationReconciliationTests

open AOC.Lib
open Xunit

(*3   4
4   3
2   5
1   3
3   9
3   3*)
// 11

type DiffValues() as this =
    inherit TheoryData<int[],int[], int>()
    do  this.Add([|3; 4; 2; 1; 3; 3|], [|4; 3; 5; 3; 9; 3|], 11)
    
type SimilarValues() as this =
    inherit TheoryData<int[],int[], int>()
    do  this.Add([|3; 4; 2; 1; 3; 3|], [|4; 3; 5; 3; 9; 3|], 31)

[<Theory; ClassData(typeof<DiffValues>)>]
let ``Two lists should find the diff (abs) between the sorted list and sum them`` (a : int[], b : int[], expected: int) : unit =
    let actual = LocationReconciliation.reconcile a b
    Assert.Equal(expected, actual)
    
[<Theory; ClassData(typeof<SimilarValues>)>]
let ``Similarity score should find how many times a number exists in the second list multiply them and then sum the total`` (a : int[], b : int[], expected: int) : unit =
    let actual = LocationReconciliation.calculateSimilarityScore a b
    Assert.Equal(expected, actual)
    
[<Theory>]
[<InlineData(3, 3)>]
[<InlineData(4, 1)>]
[<InlineData(2, 1)>]
[<InlineData(1, 1)>]
[<InlineData(100, 0)>]
let ``Count the number of times a number exists in a list`` (num: int, expected: int) : unit =
    let numArray = [|3; 4; 2; 1; 3; 3|]
    let actual = LocationReconciliation.numCount(num, numArray)
    Assert.Equal(expected, actual)