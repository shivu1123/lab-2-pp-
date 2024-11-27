type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let coaches = [
    { Name = "Quin Snyder"; FormerPlayer = true }
    { Name = "Joe Mazzulla"; FormerPlayer = true }
    { Name = "Jason Kidd"; FormerPlayer = false }
    { Name = "Charles Lee"; FormerPlayer = false }
    { Name = "Billy Donovan"; FormerPlayer = false }
]

let stats = [
    { Wins = 7; Losses = 11 }
    { Wins = 15; Losses = 3 }
    { Wins = 10; Losses = 8 }
    { Wins = 6; Losses = 11 }
    { Wins = 8; Losses = 11 }
]

let teams = [
    { Name = "Atlanta Hawks"; Coach = coaches.[0]; Stats = stats.[0] }
    { Name = "Boston Celtics"; Coach = coaches.[1]; Stats = stats.[1] }
    { Name = "Dallas Mavericks"; Coach = coaches.[2]; Stats = stats.[2] }
    { Name = "Charlotte Hornets"; Coach = coaches.[3]; Stats = stats.[3] }
    { Name = "Chicago Bulls"; Coach = coaches.[4]; Stats = stats.[4] }
]

let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

printfn "Original teams are:"
printfn "%A" teams

printfn "Successful teams are:"
printfn "%A" successfulTeams

let successPercentages = 
    successfulTeams
    |> List.map (fun team -> 
        let wins = float team.Stats.Wins
        let losses = float team.Stats.Losses
        let percentage = (wins / (wins + losses)) * 100.0
        (team.Name, percentage)
    )

printfn "Success percentages are:"
printfn "%A" successPercentages

type Cuisine =
    | Korean
    | Turkish

type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (kilometers, fuelPerKilometer) -> float kilometers * fuelPerKilometer

let activities = [
    Movie RegularWithSnacks
    Restaurant Korean
    LongDrive (100, 1.5)
]

let budgets = activities |> List.map calculateBudget

List.iteri (fun i budget -> printfn "Budget for activity%d: %f" (i + 1) budget) budgets