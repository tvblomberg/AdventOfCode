namespace AOC.Lib.Utils

module ArrayUtils =
    let omitAt index (arr: 'a array) : 'a array =
        if index < 0 || index >= arr.Length then arr
        else
            [| yield! arr[0 .. index - 1]
               yield! arr[index + 1 ..] |]