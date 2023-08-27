using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.AutoSettingsModel
{
    class SelectedTaskViewModel : BaseAutoViewModel
    {
        private RequestEvaluation requestEvaluation;
        private Question question;


        //Copy link to requestEvaluation in Heap
        public SelectedTaskViewModel(RequestEvaluation requestEvaluation, Question question)
        {
            this.requestEvaluation = requestEvaluation;
            this.question = question;
        }

        public int MemoryLimit
        {
            get
            {
                return requestEvaluation.MemoryLimit;
            }
            set
            {
                requestEvaluation.MemoryLimit = value;
                OnPropertyChanged(nameof(MemoryLimit));
            }
        }

        public int TimeLimit
        {
            get
            {
                return requestEvaluation.TimeLimit;
            }
            set
            {
                requestEvaluation.TimeLimit = value;
                OnPropertyChanged(nameof(TimeLimit));
            }
        }
    }
}
