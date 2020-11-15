open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open JobRepoDTOs.DataTransferObjects

let currentCiJobs =
    let jobs = [
        { ProjectName = "patrickp89/lazor" };
        { ProjectName = "patrickp89/halyard" };
        { ProjectName = "patrickp89/spice" } ]
    serializeJobs jobs

let app =
    choose
        [ GET >=> choose
            [ path "/" >=> OK "Hello, cibuilds@home! :)"
              path "/jobs/" >=> OK (currentCiJobs) ] ]

[<EntryPoint>]
let main argv =
    printfn "Starting cibuilds@home job repository..."
    startWebServer defaultConfig app
    0
