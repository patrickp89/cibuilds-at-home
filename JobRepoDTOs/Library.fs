namespace JobRepoDTOs

module Jobs =
    open Chiron.Formatting
    open Chiron.Mapping
    open Chiron.Operators
    open System

    type CiJob =
        { JobId: Guid option;
          ProjectName: string;
          ProjectUrl: string }
        static member ToJson (j: CiJob) =
            let jobIdString =
                match j.JobId with
                | Some(uuid)    -> (uuid.ToString ())
                | None          -> "" // TODO: use Json.missingMember instead?
            Json.write "jobId" jobIdString
            *> Json.write "projectUrl" j.ProjectUrl
            *> Json.write "projectName" j.ProjectName

    type CiJobList =
        { Jobs: CiJob list }
        static member ToJson (jl: CiJobList) =
            Json.write "jobs" jl.Jobs

    let serializeJobs (jl: CiJob List) =
        let jobList =  { Jobs = jl }
        jobList
            |> Json.serialize
            |> Json.format
