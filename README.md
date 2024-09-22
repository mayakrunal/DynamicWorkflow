# Dynamic Workflow using Temporal 

- Shows Workflow Execution with Technology agnostic activities

## Dependencies

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Java JDK 17](https://www.oracle.com/java/technologies/javase/jdk17-archive-downloads.html)
- [Python 3.11](https://www.python.org/downloads/release/python-3110/)
- Temporal SDK
  - [Nuget Package](https://www.nuget.org/packages/Temporalio)
  - [Java SDK](https://mvnrepository.com/artifact/io.temporal/temporal-sdk/1.25.1)
  - [Python SDK](https://pypi.org/project/temporalio/)
- [Temporal docker-compose](https://github.com/temporalio/docker-compose) (Running in docker)

## Execution Steps

- Run WorkerWebApi
- Run RemoteDotNet
- Run RemoteJava
- Run RemotePython

## UIs

- Temporal UI - http://localhost:8080
- WorkerWebApi - http://localhost:5000

## Payload

```sh
curl -X 'POST' \
  'http://localhost:5000/Workflow' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '[
  {
    "activityName": "Remote_Activity_2",
    "activityParams": [
      "Hi"
    ]
  },
  {
    "activityName": "remote_activity_3",
    "activityParams": [
      "Hi"
    ]
  },
  {
    "activityName": "Remote_Activity_1",
    "activityParams": [
      "Hi"
    ]
  }
]'
```

## Result

- The workflow will run the remote activities in defined order agnostics of the thier implementation.