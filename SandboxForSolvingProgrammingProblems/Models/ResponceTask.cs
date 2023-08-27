using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Models
{
    public class ResponceTask
    {
        [JsonPropertyName("question")]
        public Question Question { get; set; }
    }
}
