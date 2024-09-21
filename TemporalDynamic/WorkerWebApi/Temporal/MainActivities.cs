using Temporalio.Activities;

namespace WorkerWebApi.Temporal;

public class MainActivities
{
    [Activity]
    public string MainActivity(String input) => $"DOTNET WORKFLOW SAYS, {input}!";
}
