using Temporalio.Activities;

namespace RemoteDotnet;
public class RemoteActivities
{
    [Activity]
    public string Remote_Activity_1(String input) => $"DOTNET REMOTE ACTIVITY SAYS, {input}!";
}
