using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;

        public MainViewModel()
        {
            this.selectedViewModel = new WorkspaceViewModel();
        }

        public BaseViewModel SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }
            set
            {
                if (value is not BaseViewModel)
                {
                    selectedViewModel = new WorkspaceViewModel();
                }
                selectedViewModel = value;
            }
        }
    }
}
