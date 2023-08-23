using SandboxForSolvingProgrammingProblems.Infrastructure.Secret;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API
{
    class ManagerSandboxAPI : ManagerAPI
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
    }
}
