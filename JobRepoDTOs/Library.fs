namespace JobRepoDTOs

module DataTransferObjects =
    open Chiron.Formatting
    open Chiron.Mapping

    type Job =
        { ProjectName: string }
        static member ToJson (j: Job) =
            Json.write "projectName" j.ProjectName

    type JobList =
        { Jobs: Job list }
        static member ToJson (jl: JobList) =
            Json.write "jobs" jl.Jobs

    let serializeJobs (jl: Job List) =
        let jobList =  { Jobs = jl }
        jobList
            |> Json.serialize
            |> Json.format
