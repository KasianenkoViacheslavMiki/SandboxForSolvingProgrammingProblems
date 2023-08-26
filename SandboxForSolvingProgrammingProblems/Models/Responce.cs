using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class Responce
    {
        [JsonPropertyName("request_status")]
        public RequestStatus RequestStatus { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("he_id")]
        public string HeId { get; set; }

        [JsonPropertyName("status_update_url")]
        public string StatusUpdateUrl { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }
}