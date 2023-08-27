using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    public class CodeSnippet
    {
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("langSlug")]
        public string LangSlug { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
