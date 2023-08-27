using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface
{
    public interface IManagerTask
    {
        public Task<IDictionary<string,string>> GetTasksList();
        public Task<ResponceTask> GetTask(string nameQuestion);

    }
}
