namespace WorkerWebApi.Temporal;

public class TemporalConfig
{

    public const string Section = "Temporal";

    public string Host { get; set; } = string.Empty;

    public string WorkerNamespace { get; set; } = string.Empty;

    public string TaskQueue { get; set; } = string.Empty;

    public Dictionary<string, string> ActivityMap { get; set; } = new Dictionary<string, string>();
}
