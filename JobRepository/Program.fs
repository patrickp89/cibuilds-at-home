open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open System
open JobRepoDTOs.Jobs

let currentCiJobs =
    let jobs = [
        { JobId = Some (Guid.NewGuid ());
            ProjectName = "patrickp89/lazor";
            ProjectUrl = "https://github.com/patrickp89/lazor" };
        { JobId = Some (Guid.NewGuid ());
            ProjectName = "patrickp89/halyard";
            ProjectUrl = "https://github.com/patrickp89/halyard" };
        { JobId = Some (Guid.NewGuid ());
            ProjectName = "patrickp89/spice" ;
            ProjectUrl = "https://github.com/patrickp89/spice"} ]
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
