using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SandboxForSolvingProgrammingProblems.Models
{
    [DataContract]
    public class Stat
    {
        [JsonPropertyName("question_id")]
        public int QuestionId { get; set; }

        [JsonPropertyName("question__article__live")]
        public bool? QuestionArticleLive { get; set; }

        [JsonPropertyName("question__article__slug")]
        public string QuestionArticleSlug { get; set; }

        [JsonPropertyName("question__article__has_video_solution")]
        public bool? QuestionArticleHasVideoSolution { get; set; }

        [JsonPropertyName("question__title")]
        public string QuestionTitle { get; set; }

        [JsonPropertyName("question__title_slug")]
        public string QuestionTitleSlug { get; set; }

        [JsonPropertyName("question__hide")]
        public bool QuestionHide { get; set; }

        [JsonPropertyName("total_acs")]
        public int TotalAcs { get; set; }

        [JsonPropertyName("total_submitted")]
        public int TotalSubmitted { get; set; }

        [JsonPropertyName("frontend_question_id")]
        public int FrontendQuestionId { get; set; }

        [JsonPropertyName("is_new_question")]
        public bool IsNewQuestion { get; set; }
    }


}
