using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class StatStatusPair
    {
        [JsonPropertyName("stat")]
        public Stat Stat { get; set; }

        [JsonPropertyName("status")]
        public object Status { get; set; }

        [JsonPropertyName("difficulty")]
        public Difficulty Difficulty { get; set; }

        [JsonPropertyName("paid_only")]
        public bool Paid_only { get; set; }

        [JsonPropertyName("is_favor")]
        public bool IsFavor { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

        [JsonPropertyName("progress")]
        public int Progress { get; set; }
    }


}
