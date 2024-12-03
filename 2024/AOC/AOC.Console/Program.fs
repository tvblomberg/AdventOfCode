namespace AOC.Console

open System
open System.IO
open AOC.Console.ChallengeFactory

module Program =
    let dayString = Environment.GetCommandLineArgs()[1]
    let filePath = Environment.GetCommandLineArgs()[2]

    let readFile (filePath: string) : string[] =
        File.ReadAllLines(filePath)

    // Usage
    let lines = readFile filePath
    
    let dayOfChallenge =  Enum.Parse<DaysOfChallenge> dayString

    let dayFunc = create dayOfChallenge
    
    dayFunc lines

