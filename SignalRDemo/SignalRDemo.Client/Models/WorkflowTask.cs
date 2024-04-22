namespace SignalRDemo.Models
{
    public class WorkflowTask
    {
        public string? ElementId { get; set; }
        public long ProcessInstanceKey { get; set; }
        public Dictionary<string, object>? Variables { get; set; }
        public long TaskKey { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public string? Type { get; set; }
        public long ProcessDefinitionKey { get; set; }
        public int Retries { get; set; }
        public string? TaskName { get; set; }
        public string? Assignee { get; set; }
        public string? State { get; set; }
        public int ProcessDefinitionVersion { get; set; }
        public DateTime? Creation { get; set; }
    }
}
