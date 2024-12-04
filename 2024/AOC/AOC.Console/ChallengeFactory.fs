namespace AOC.Console

module ChallengeFactory =
    type DaysOfChallenge =
        | Day1 = 1
        | Day2 = 2
        | Day3 = 3
        
    let create = fun (day: DaysOfChallenge) ->
        match day with
        | DaysOfChallenge.Day1 -> Day1.run
        | DaysOfChallenge.Day2 -> Day2.run
        | DaysOfChallenge.Day3 -> Day3.run
        | _ -> failwith "Invalid day"