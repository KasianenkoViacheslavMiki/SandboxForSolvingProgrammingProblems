using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu
{
    class ManualSettingsSideViewModel : BaseSideViewModel
    {
        private RequestEvaluation requestEvaluation;

        //Copy link to requestEvaluation in Heap
        public ManualSettingsSideViewModel(RequestEvaluation requestEvaluation)
        {
            this.requestEvaluation = requestEvaluation;
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
