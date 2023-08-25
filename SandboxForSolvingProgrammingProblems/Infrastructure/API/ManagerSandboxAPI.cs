using SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret.Interface;
using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API
{
    class ManagerSandboxAPI : ManagerAPI, ISandbox
    {
        IGetAPIKey getAPIKey;

        private readonly string apikey;

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

        public Task<Responce> GetCodeOnEvaluation(RequestEvaluation requestEvaluation)
        {
            throw new NotImplementedException();
        }

        public Task<Responce> GetStatus(string id)
        {
            throw new NotImplementedException();
        }
    }
}
