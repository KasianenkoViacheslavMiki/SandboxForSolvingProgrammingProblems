using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class Result
    {
        [JsonPropertyName("run_status")]
        public RunStatus RunStatus { get; set; }

        [JsonPropertyName("compile_status")]
        public string CompileStatus { get; set; }
    }
}