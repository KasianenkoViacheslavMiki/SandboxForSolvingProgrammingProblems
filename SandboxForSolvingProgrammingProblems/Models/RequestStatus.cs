﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class RequestStatus
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}