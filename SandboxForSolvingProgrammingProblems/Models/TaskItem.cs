using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Models
{
    public class TaskItem
    {
        public TaskItem(string key, string value)
        {
            QuestionTitleSlug = key;
            QuestionTitle = value;
        }

        public string QuestionTitleSlug { get; set; }
        public string QuestionTitle { get; set; }
    }
}
