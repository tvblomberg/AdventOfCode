module MemoryMulParserTests
open AOC.Lib.MemoryMulParser
open Xunit

[<Fact>]
let ``parse should return the valid digits in pairs from a string`` () : unit =
    let input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
    let expected = [| (2, 4); (5, 5); (11, 8); (8, 5) |]
    
    let actual = parse input
    
    Assert.Equal<int * int>(expected, actual)
    
[<Fact>]
let ``parseAndMultiple should multiply all the valid values and sum them`` () : unit =
    let input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
    let expected = 2*4 + 5*5 + 11*8 + 8*5
    
    let actual = parseAndMultiply input
    
    Assert.Equal(expected, actual)
    
[<Fact>]
let ``sanitizeParseAndMultiply should remove dont't up to do and multiply all the valid values and sum them`` () : unit =
    let input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
    let expected = 2*4 + 8*5
    
    let actual = sanitizeParseAndMultiply input
    
    Assert.Equal(expected, actual)

[<Fact>]
let ``sanitizeParseAndMultiply should remove dont't till the end and multiply all the valid values and sum them`` () : unit =
    let input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)un?mul(8,5))"
    let expected = 2*4
    
    let actual = sanitizeParseAndMultiply input
    
    Assert.Equal(expected, actual)

[<Fact>]
let ``sanitizeParseAndMultiply should remove multiple dont'ts and multiply all the valid values and sum them`` () : unit =
    let input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))don't()_mul(5,5)"
    let expected = 2*4 + 8*5
    
    let actual = sanitizeParseAndMultiply input
    
    Assert.Equal(expected, actual)

[<Fact>]
let ``sanitizeParseAndMultiply two donts and a do should not disable the `` () : unit =
    let input = "xmul(2,4)&mul[3,7]!^don't()dont't()do()?mul(8,5))don't()_mul(5,5)"
    let expected = 2*4 + 8*5
    
    let actual = sanitizeParseAndMultiply input
    
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("xmul(2%&mul[3,7]!@^do_not_mul(5+mul(32,64]then(mul(11mul(8)", "No matches")>]
[<InlineData("mul(n,n)", "No numbers")>]
[<InlineData("mul(n,7)", "Partial numbers")>]
[<InlineData("mul(1234,7)", "Left number should be 1 to 3 digits")>]
[<InlineData("mul(7,1234)", "Right number should be 1 to 3 digits")>]
let ``parse bad string should return 0 results`` (input, _) : unit =
    let expected = []
    
    let actual = parse input
    
    Assert.Equal<int * int>(expected, actual)
    
[<Theory>]
[<InlineData("mul(0,0)", 0, 0, "All zeros")>]
[<InlineData("mul(1,0)", 1, 0, "1 left")>]
[<InlineData("mul(0,1)", 0, 1, "1 right")>]
[<InlineData("mul(1,1)", 1, 1, "1 digit in both")>]
[<InlineData("mul(10,1)", 10, 1, "2 digits left")>]
[<InlineData("mul(1,10)", 1, 10, "2 digits right")>]
[<InlineData("mul(10,10)", 10, 10, "2 digits in both")>]
[<InlineData("mul(100,1)", 100, 1, "3 digits left")>]
[<InlineData("mul(1,100)", 1, 100, "3 digits right")>]
[<InlineData("mul(100,100)", 100, 100, "3 digits in both")>]
[<InlineData("mul(999,999)", 999, 999, "3 digits max in both")>]
let ``parse should parse numbers up to 3 digits`` (input, expectedDigit1, expectedDigit2, _) : unit =
    let expected = [expectedDigit1, expectedDigit2]
    
    let actual = parse input
    
    Assert.Equal<int * int>(expected, actual)
    
