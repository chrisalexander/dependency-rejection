type Date = {
    Day : int;
    Month : int;
    Year : int
}

type BrownBag = {
    Day : Date;
    Presenter : string;
    Topic : string
}

type BrownBagDto = {
    Data : byte[]
}

let getBrownBags (connectionString : string) day =
    [{ Day = day; Presenter = "Chris"; Topic = "F#" }]

let tryAcceptBrownBag (connectionString : string) brownBag =
    brownBag.Presenter = "Chris"

let connectionString = "udp://127.0.0.1"

let theBrownBag = { Day = { Day = 17; Month = 5; Year = 2017 }; Presenter = "Chris"; Topic = "F#" }

// New code starts here
let flip f x y = f y x

let canAcceptBrownBag capacity (allBrownBags : BrownBag list) (brownBag : BrownBag) =
    if allBrownBags.Length >= capacity
    then brownBag |> Some
    else None

let handleNewBrownBagComposition brownBag =
    brownBag.Day
    |> getBrownBags connectionString
    |> flip (canAcceptBrownBag 1) brownBag
    |> Option.map (tryAcceptBrownBag connectionString)

handleNewBrownBagComposition theBrownBag