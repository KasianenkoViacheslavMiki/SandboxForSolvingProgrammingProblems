using SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret.Interface;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using SandboxForSolvingProgrammingProblems.Models;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API
{
    class ManagerTaskAPI : ManagerAPI, IManagerTask
    {

        GraphQLHttpClient graphQLClient;

        private static ManagerTaskAPI instance;
        private static ManagerTaskAPI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManagerTaskAPI();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public ManagerTaskAPI() : base()
        {
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://leetcode.com/graphql", UriKind.Absolute),
            };

            this.graphQLClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer(), httpClient);

            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
        }
        public static ManagerTaskAPI GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ManagerTaskAPI();
            }
            return Instance;
        }
        public async Task<IDictionary<string, string>> GetTasksList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var content = await httpClient.GetFromJsonAsync<ResponceTaskList>("https://leetcode.com/api/problems/all/");

            foreach (var task in content.StatStatusPairs)
            {
                result.Add(task.Stat.QuestionTitleSlug, task.Stat.QuestionTitle);
            }

            return result;
        }

        public async Task<ResponceTask> GetTask(string nameQuestion)
        {
            var queryObject = new GraphQLRequest
            {
                Query = @"query getQuestionDetail($titleSlug: String!) {
                    question(titleSlug: $titleSlug) {
                        questionId
                        title
                        difficulty
                        likes
                        dislikes
                        isLiked
                        isPaidOnly
                        stats
                        status
                        content
                        topicTags {
                            name
                        }
                        codeSnippets {
                            lang
                            langSlug
                            code
                        }
                        sampleTestCase
                    }
                }",
                Variables = new { titleSlug = nameQuestion },
                OperationName= "getQuestionDetail"
            };


            var result = graphQLClient.SendQueryAsync<ResponceTask>(queryObject).GetAwaiter().GetResult();

            return result.Data;
        }
    }
}
