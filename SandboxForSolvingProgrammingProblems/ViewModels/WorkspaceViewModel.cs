using SandboxForSolvingProgrammingProblems.ViewModels.SideMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.ViewModels
{
    class WorkspaceViewModel : BaseViewModel
    {
        private BaseSideViewModel selectedSideView;

        public WorkspaceViewModel()
        {
            this.selectedSideView = new ManualSettingsSideViewModel();
        }

        public BaseSideViewModel SelectedSideView
        {
            get
            {
                return selectedSideView;
            }
            set
            {
                if (value is not BaseSideViewModel)
                {
                    selectedSideView = new ManualSettingsSideViewModel();
                }
                selectedSideView = value;
            }
        }
    }
}
