# CIBUILDS@home
A distributed CI build platform, inspired by awesome volunteer computing
projects like [SETI@home](https://setiathome.berkeley.edu/).

## What's the idea?
If you want to offer some of your CPU cycles to run CI builds for, say,
your favourite open-source project, launch the CIBUILDS@home runner on your
machine! :) This platform aims to (in the future) provide projects with a
cost-efficient (i.e. free) way to run their CI builds, as big players are
unfortunately [turning their backs](https://www.jeffgeerling.com/blog/2020/travis-cis-new-pricing-plan-threw-wrench-my-open-source-works)
on open-source projects.

## How to build it?
Install [.NET Core 3.1](https://dotnet.microsoft.com/download) or higher. Then run:
```bash
$ dotnet build
$ dotnet test
```

## How to run it?
Right now, everything is WIP. :) To test the job repo, run:
```bash
$ cd JobRepository && dotnet run
$ curl http://127.0.0.1:8080/jobs/
```
