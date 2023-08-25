using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public class RunStatus
{
    [JsonPropertyName("memory_used")]
    public double MemoryUsed { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("time_used")]
    public double TimeUsed { get; set; }

    [JsonPropertyName("signal")]
    public string Signal { get; set; }

    [JsonPropertyName("exit_code")]
    public string ExitCode { get; set; }

    [JsonPropertyName("status_detail")]
    public string StatusDetail { get; set; }

    [JsonPropertyName("stderr")]
    public string StdErr { get; set; }

    [JsonPropertyName("output")]
    public string Output { get; set; }

    [JsonPropertyName("request_NOT_OK_reason")]
    public string RequestNotOkReason { get; set; }

    [JsonPropertyName("request_OK")]
    public string RequestOk { get; set; }
}
