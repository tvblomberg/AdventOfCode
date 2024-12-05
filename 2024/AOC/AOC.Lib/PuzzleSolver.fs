namespace AOC.Lib

module PuzzleSolver =
    type private Direction =
    | Right
    | Down
    | Left
    | Up
    | DownRightDiagonal
    | DownLeftDiagonal
    | UpRightDiagonal
    | UpLeftDiagonal
    
    let private directionToDelta = function
        | Right -> (0, 1)
        | Down  -> (1, 0)
        | Left  -> (0, -1)
        | Up    -> (-1, 0)
        | DownRightDiagonal -> (1, 1)
        | DownLeftDiagonal -> (1, -1)
        | UpRightDiagonal -> (-1, 1)
        | UpLeftDiagonal -> (-1, -1)
    
    let private isInBounds (grid: char[][]) (row: int, col: int) =
        row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length

    let private isMatch (grid: char[][], row: int, col: int, word: string, direction: Direction) =
        let deltaRow, deltaCol = directionToDelta direction
        let rec matchLoop index =
            if index = word.Length then true
            else
                let newRow, newCol = row + index * deltaRow, col + index * deltaCol
                if not (isInBounds grid (newRow, newCol)) then false
                elif grid[newRow][newCol] <> word[index] then false
                else matchLoop (index + 1)
        matchLoop 0

    let isMatchRight (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.Right)
        
    let isMatchLeft (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.Left)
        
    let isMatchDown (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.Down)
        
    let isMatchDownRightDiagonal (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.DownRightDiagonal)
        
    let isMatchDownLeftDiagonal (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.DownLeftDiagonal)

    let isMatchUp (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.Up)

    let isMatchUpRightDiagonal (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.UpRightDiagonal)

    let isMatchUpLeftDiagonal (grid: char[][], row: int, col: int, word: string) =
        isMatch(grid, row, col, word, Direction.UpLeftDiagonal)
        
    let solveForAllDirections (grid: char[][], word: string) =
        let directions = [|
            isMatchRight
            isMatchLeft
            isMatchDown
            isMatchUp
            isMatchDownRightDiagonal
            isMatchDownLeftDiagonal
            isMatchUpRightDiagonal
            isMatchUpLeftDiagonal
        |]
        
        let rowLength = grid.Length
        let colLength = grid.[0].Length

        seq {
            for row in 0 .. rowLength - 1 do
                for col in 0 .. colLength- 1 do
                    yield! directions |> Seq.map (fun dir -> dir(grid, row, col, word))
        }
        |> Seq.filter id
        |> Seq.length

    let solveForX (data: char[][]) =
        let rows = data.Length
        let cols = data.[0].Length
        let mutable count = 0

        let _set = Set.ofList ['M'; 'S']

        // Find 'A' as the center of the cross, then check the diagonals
        for r in 1 .. rows - 2 do
            for c in 1 .. cols - 2 do
                if data.[r].[c] = 'A' then
                    let diag1 = Set.ofList [data.[r - 1].[c - 1]; data.[r + 1].[c + 1]]
                    let diag2 = Set.ofList [data.[r - 1].[c + 1]; data.[r + 1].[c - 1]]
                    if diag1 = _set && diag2 = _set then
                        count <- count + 1

        count

        
   