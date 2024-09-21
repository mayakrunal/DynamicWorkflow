using System.ComponentModel.DataAnnotations;

namespace WorkerWebApi.Model;

public class ActivityExecuteModel
{
    [Required]
    public string ActivityName { get; set; } = String.Empty;

    public List<object> ActivityParams { get; set; } = [];
}
