using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class RequestEvaluation
    {
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("input")]
        public string Input { get; set; }

        [JsonPropertyName("memory_limit")]
        public int MemoryLimit { get; set; }

        [JsonPropertyName("time_limit")]
        public int TimeLimit { get; set; }

        [JsonPropertyName("context")]
        public Dictionary<string, object> Context { get; set; }

        [JsonPropertyName("callback")]
        public string Callback { get; set; }
    }
}
