using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Temporalio.Client;
using WorkerWebApi.Model;
using WorkerWebApi.Temporal;

namespace WorkerWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkflowController : ControllerBase
{

    private readonly ILogger<WorkflowController> _logger;
    private readonly ITemporalClient client;
    private readonly TemporalConfig config;

    public WorkflowController(ILogger<WorkflowController> logger,
        IOptions<TemporalConfig> options,
        ITemporalClient client)
    {
        _logger = logger;
        this.client = client;
        this.config = options.Value;
    }

    [HttpPost]
    public async Task<string> Execute(List<ActivityExecuteModel> activities)
    {

        //var client = await clientTask;
        var workflowId = Guid.NewGuid().ToString();
        var queueMap = config.ActivityMap;

        await client.ExecuteWorkflowAsync("MainWorkflow",
            [activities, queueMap],
            new WorkflowOptions()
            {
                Id = workflowId,
                TaskQueue = config.TaskQueue
            });

        // if you want to get result of the workflow
        /*var handle = client.GetWorkflowHandle(workflowId);
        return await handle.GetResultAsync<string>();*/

        return workflowId;
    }
}
