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

let handleNewBrownBag getBrownBags tryAcceptBrownBag maxBrownBagsPerDay brownBag =
    let existingBrownBags = (getBrownBags brownBag.Day : BrownBag list)

    if existingBrownBags.Length >= maxBrownBagsPerDay
    then (tryAcceptBrownBag brownBag : bool) |> Some
    else None

let connectionString = "udp://127.0.0.1"
let getBrownBagsSpecific = getBrownBags connectionString
let tryAcceptBrownBagSpecific = tryAcceptBrownBag connectionString

let theBrownBag = { Day = { Day = 17; Month = 5; Year = 2017 }; Presenter = "Chris"; Topic = "F#" }

handleNewBrownBag getBrownBagsSpecific tryAcceptBrownBagSpecific 1 theBrownBag