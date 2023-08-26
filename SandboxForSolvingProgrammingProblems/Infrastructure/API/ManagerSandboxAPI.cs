using SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret.Interface;
using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API
{
    class ManagerSandboxAPI : ManagerAPI, ISandbox
    {
        IGetAPIKey getAPIKey;

        private readonly string apikey;
        private readonly string endpointEvaluationURL = "https://api.hackerearth.com/v4/partner/code-evaluation/submissions/";

        private static ManagerSandboxAPI instance;
        private static ManagerSandboxAPI Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public ManagerSandboxAPI(): base()
        {
            getAPIKey = new SecretKey();
            apikey = getAPIKey.GetAPIKey();

            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
            this.httpClient.DefaultRequestHeaders.Add("client-secret", apikey);
        }

        public static ManagerSandboxAPI GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ManagerSandboxAPI();
            }
            return Instance;
        }

        public async Task<ResponceEvaluation> GetCodeOnEvaluation(RequestEvaluation requestEvaluation)
        {
            var content = new StringContent(JsonSerializer.Serialize(requestEvaluation));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync(endpointEvaluationURL, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponceEvaluation>(responseContent);
            return result;
        }

        public async Task<ResponceEvaluation> GetStatus(string id)
        {
            var response = await httpClient.GetAsync(id);
            string responseContent = await response.Content.ReadAsStringAsync();
            ResponceEvaluation result = JsonSerializer.Deserialize<ResponceEvaluation>(responseContent);

            return result;
        }

        public async Task<string> GetOutput(string id)
        {
            var response = await httpClient.GetAsync(id);
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
