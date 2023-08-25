using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API
{
    abstract class ManagerAPI
    {
        protected readonly HttpClient httpClient;

        public ManagerAPI()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
        }
    }
}
