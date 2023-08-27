using SandboxForSolvingProgrammingProblems.Infrastructure;
using SandboxForSolvingProgrammingProblems.Infrastructure.Parser;
using SandboxForSolvingProgrammingProblems.Infrastructure.Parser.Interface;
using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.TaskSettingsModel
{
    class SelectedTaskViewModel : BaseAutoViewModel
    {
        private RequestEvaluation requestEvaluation;
        private Question question;

        private IParseContent parseContent;

        private ICommand returnCommand;
        
        public ICommand ReturnCommand
        {
            get
            {
                return returnCommand ?? (returnCommand = new RelayCommand(async obj =>
                {
                    OnReturnToListTask("");
                }));
            }
        }

        //Copy link to requestEvaluation in Heap
        public SelectedTaskViewModel(RequestEvaluation requestEvaluation, Question question)
        {
            parseContent = new ParserContent();
            this.requestEvaluation = requestEvaluation;
            this.question = question;
            parseContent.GetParseContentTask(this.question.Content);
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Content));
        }


        public string Title
        {
            get
            {
                return this.question.Title;
            }
        }
        public string Content
        {
            get
            {
                return this.question.Content;
            }
        }
    }
}
