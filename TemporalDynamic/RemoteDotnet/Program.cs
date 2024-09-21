using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RemoteDotnet;
using Temporalio.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(loggingBuilder => loggingBuilder.AddSimpleConsole().SetMinimumLevel(LogLevel.Information))
    .ConfigureServices((hostBuilder, svc) =>
    {
        svc.AddTemporalClient(hostBuilder.Configuration["Temporal:Host"]!,
                              hostBuilder.Configuration["Temporal:WorkerNamespace"]!);

        svc.AddHostedTemporalWorker(clientTargetHost: hostBuilder.Configuration["Temporal:Host"]!,
                                    clientNamespace: hostBuilder.Configuration["Temporal:WorkerNamespace"]!,
                                    taskQueue: hostBuilder.Configuration["Temporal:TaskQueue"]!).
            // Add the activities class at the scoped level
            AddScopedActivities<RemoteActivities>();
    })
    .Build();

await host.RunAsync();
