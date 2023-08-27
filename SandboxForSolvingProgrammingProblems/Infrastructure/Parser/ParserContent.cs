using SandboxForSolvingProgrammingProblems.Infrastructure.Parser.Interface;
using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.Parser
{
    class ParserContent : IParseContent
    {
        string tagsHtml = @"(<.*?>)";
        string input = @"Input:(.*)";
        string output = @"Output:(.*)";

        public ResultParse GetParseContentTask(string? value)
        {
            if (value == null)
            {
                return new ResultParse();
            }
            var parse = value.Split("&nbsp;");
            ResultParse task = new ResultParse();
            task.Decription = Regex.Replace(parse[0], tagsHtml, "");
            task.Input = Regex.Replace(parse[1], tagsHtml, "");
            task.Input = Regex.Match(task.Input, input).Value;
            task.ExpectedOutput = Regex.Replace(parse[1], tagsHtml, "");
            task.ExpectedOutput = Regex.Match(task.ExpectedOutput, output).Value;

            return task;
        }
    }
}
