open Suave
open System

[<EntryPoint>]
let main argv =
    printfn "Starting cibuilds@home job repository..."
    startWebServer defaultConfig (Successful.OK "Hello, cibuilds@home! :)")
    0
