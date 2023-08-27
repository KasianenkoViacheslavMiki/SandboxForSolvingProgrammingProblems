using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    public class Question
    {
        [JsonPropertyName("questionId")]
        public string QuestionId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("likes")]
        public int Likes { get; set; }

        [JsonPropertyName("dislikes")]
        public int Dislikes { get; set; }

        [JsonPropertyName("isLiked")]
        public object IsLiked { get; set; }

        [JsonPropertyName("isPaidOnly")]
        public bool IsPaidOnly { get; set; }

        [JsonPropertyName("stats")]
        public string Stats { get; set; }

        [JsonPropertyName("status")]
        public object Status { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("topicTags")]
        public List<TopicTag> TopicTags { get; set; }

        [JsonPropertyName("codeSnippets")]
        public List<CodeSnippet> CodeSnippets { get; set; }

        [JsonPropertyName("sampleTestCase")]
        public string SampleTestCase { get; set; }
    }
}
