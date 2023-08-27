using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.Parser.Interface
{
    interface IParseContent
    {
        public ResultParse GetParseContentTask(string value);
    }
}
