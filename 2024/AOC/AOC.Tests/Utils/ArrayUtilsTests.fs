module AOC.Tests.Utils.ArrayUtilsTests

open Xunit
open AOC.Lib.Utils.ArrayUtils

[<Fact>]
let ``omitAt 0 should remove the first element from the array`` () : unit =
    let actual = omitAt 0 [|1; 2; 3; 4; 5|]
    let expected = [|2; 3; 4; 5|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``omitAt -1 should return the entire array`` () : unit =
    let actual = omitAt -1 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 3; 4; 5|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``omitAt middle index should return the array without that index`` () : unit =
    let actual = omitAt 2 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 4; 5|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``omitAt end index should return the array without that index`` () : unit =
    let actual = omitAt 4 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 3; 4|]
    
    Assert.Equal<int array>(expected, actual)
    
[<Fact>]
let ``omitAt bad index should return the entire array`` () : unit =
    let actual = omitAt 20 [|1; 2; 3; 4; 5|]
    let expected = [|1; 2; 3; 4; 5;|]
    
    Assert.Equal<int array>(expected, actual)