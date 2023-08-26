using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface
{
    public interface ISandbox
    {
        public Task<ResponceEvaluation> GetCodeOnEvaluation(RequestEvaluation requestEvaluation);
        public Task<ResponceEvaluation> GetStatus(string id);
        public Task<string> GetOutput(string id);
    }
}
