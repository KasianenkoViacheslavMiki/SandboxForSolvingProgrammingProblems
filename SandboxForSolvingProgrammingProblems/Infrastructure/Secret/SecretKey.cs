using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SandboxForSolvingProgrammingProblems.Infrastructure.API;
using SandboxForSolvingProgrammingProblems.Infrastructure.Secret.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.Secret
{
    public class SecretKey : IGetAPIKey
    {
        IConfigurationRoot configurationRoot;
        public SecretKey() 
        {
            configurationRoot = new ConfigurationBuilder()
                                .AddJsonFile($"secrets.json", optional: false, reloadOnChange: true)
                                .AddUserSecrets<HackerEarth>()
                                .Build();
        }

        public string GetAPIKey()
        {
            return configurationRoot["HackerEarth:ApiKey"];
        }
    }
}
