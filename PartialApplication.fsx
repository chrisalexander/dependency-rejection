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

let getBrownBags (connectionString : string) day =
    [{ Day = day; Presenter = "Chris"; Topic = "F#" }]

let tryAcceptBrownBag (connectionString : string) brownBag =
    brownBag.Presenter = "Chris"

let connectionString = "udp://127.0.0.1"

let theBrownBag = { Day = { Day = 17; Month = 5; Year = 2017 }; Presenter = "Chris"; Topic = "F#" }

let handleNewBrownBag getBrownBags tryAcceptBrownBag capacity brownBag =
    let existingBrownBags = (getBrownBags brownBag.Day : BrownBag list)

    if existingBrownBags.Length >= capacity
    then (tryAcceptBrownBag brownBag : bool) |> Some
    else None

let getBrownBagsSpecific = getBrownBags connectionString
let tryAcceptBrownBagSpecific = tryAcceptBrownBag connectionString

handleNewBrownBag getBrownBagsSpecific tryAcceptBrownBagSpecific 1 theBrownBag