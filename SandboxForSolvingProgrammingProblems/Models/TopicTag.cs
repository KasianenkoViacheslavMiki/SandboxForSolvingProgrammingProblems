using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    public class TopicTag
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
