using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class Difficulty
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }
    }
}
