using Temporalio.Extensions.Hosting;
using WorkerWebApi.Temporal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TemporalConfig>(builder.Configuration.GetSection(TemporalConfig.Section));

builder.Services.AddTemporalClient(builder.Configuration["Temporal:Host"]!,
                                   builder.Configuration["Temporal:WorkerNamespace"]!);
builder.Services
    .AddHostedTemporalWorker(clientTargetHost: builder.Configuration["Temporal:Host"]!,
                                         clientNamespace: builder.Configuration["Temporal:WorkerNamespace"]!,
                                         taskQueue: builder.Configuration["Temporal:TaskQueue"]!)
                .AddWorkflow<MainWorkflow>()
                .AddScopedActivities<MainActivities>();

//builder.Services.AddHostedService<TemporalRunner>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
