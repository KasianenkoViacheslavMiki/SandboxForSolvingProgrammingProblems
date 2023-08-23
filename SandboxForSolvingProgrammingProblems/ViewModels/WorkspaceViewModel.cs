using SandboxForSolvingProgrammingProblems.Infrastructure.API;
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
        private ManagerSandboxAPI ManagerSandboxAPI;
        private bool isCustom;

        public bool IsCustom
        {
            get 
            { 
                return isCustom; 
            }
            set 
            {
                isCustom = value;
                OnPropertyChanged(nameof(IsCustom));
            }
        }

        public WorkspaceViewModel()
        {
            this.selectedSideView = new ManualSettingsSideViewModel();
            ManagerSandboxAPI = ManagerSandboxAPI.GetInstance();
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
