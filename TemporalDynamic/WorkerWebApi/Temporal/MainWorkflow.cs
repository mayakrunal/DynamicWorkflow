using Temporalio.Converters;
using Temporalio.Workflows;
using WorkerWebApi.Model;

namespace WorkerWebApi.Temporal;

[Workflow(Dynamic = true)]
public class MainWorkflow()
{
    [WorkflowRun]
    public async Task<List<object>> RunAsync(IRawValue[] args)
    {
        var executeModels = Workflow.PayloadConverter.ToValue<List<ActivityExecuteModel>>(args[0]);
        var queueMap = Workflow.PayloadConverter.ToValue<Dictionary<string, string>>(args[1]);

        List<object> results = [];

        foreach (var m in executeModels)
        {
            var result = await Workflow.ExecuteActivityAsync<object>(m.ActivityName,
                m.ActivityParams,
                new ActivityOptions()
                {
                    StartToCloseTimeout = TimeSpan.FromMinutes(5),
                    TaskQueue = queueMap.GetValueOrDefault(m.ActivityName),
                });

            results.Add(result);
        }

        return results;
    }
}
