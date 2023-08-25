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
        public Task<Responce> GetCodeOnEvaluation(RequestEvaluation requestEvaluation);
        public Task<Responce> GetStatus(string id);
        public Task<string> GetOutput(string id);
    }
}
