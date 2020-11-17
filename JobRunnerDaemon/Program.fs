open FSharp.Data
open Quartz
open Quartz.Impl
open System
open System.Threading.Tasks
open JobRepoDTOs.Jobs

let fetchCiJobList (rootUrl: string) =
    let url = rootUrl + "/jobs/" // TODO: use F# 5.0's string interpolation!
    try
        Some (Http.RequestString(url)) // TODO: async request instead!
    with
    | :? Net.WebException as ex -> printfn "%s" ex.Message; None
    | _ -> printfn "Something went wrong!" ; None

type FetchCiJobListQuartzJob =
    interface IJob with
        member x.Execute(context: IJobExecutionContext): Task =
            let jl = fetchCiJobList "http://localhost:8080"
            match jl with
            | Some jl -> Console.Out.WriteLineAsync("fetched some CI jobs: %s" + jl)
                         // TODO: trigger a CI build for one/all of the fetched jobs
            | None -> Console.Out.WriteLineAsync("Couldn't fetch any CI jobs")

let createScheduler =
    let factory = StdSchedulerFactory ()
    factory.GetScheduler ()

[<EntryPoint>]
let main argv =
    printfn "Starting Quartz scheduler..."
    let scheduler: IScheduler =
        createScheduler
        |> Async.AwaitTask
        |> Async.RunSynchronously
    scheduler.Start () |> ignore
    let quartzJob = JobBuilder
                        .Create<FetchCiJobListQuartzJob>()
                        .WithIdentity("jlFetcher")
                        .Build()
    let trigger = TriggerBuilder
                    .Create()
                    .WithIdentity("jlFetcherTrigger", "jobApiGroup")
                    .WithSimpleSchedule(fun builder -> builder.WithIntervalInSeconds(5).RepeatForever() |> ignore)
                    .Build()
    scheduler.ScheduleJob(quartzJob, trigger) |> ignore
    0
