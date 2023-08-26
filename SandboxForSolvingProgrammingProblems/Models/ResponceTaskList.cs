using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class ResponceTaskList
    {
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("num_solved")]
        public int NumSolved { get; set; }

        [JsonPropertyName("num_total")]
        public int NumTotal { get; set; }

        [JsonPropertyName("ac_easy")]
        public int AcEasy { get; set; }

        [JsonPropertyName("ac_medium")]
        public int AcMedium { get; set; }

        [JsonPropertyName("ac_hard")]
        public int AcHard { get; set; }

        [JsonPropertyName("stat_status_pairs")]
        public List<StatStatusPair> StatStatusPairs { get; set; }

        [JsonPropertyName("frequency_high")]
        public int FrequencyHigh { get; set; }

        [JsonPropertyName("frequency_mid")]
        public int FrequencyMid { get; set; }

        [JsonPropertyName("category_slug")]
        public string CategorySlug { get; set; }
    }


}
