using SandboxForSolvingProgrammingProblems.Infrastructure;
using SandboxForSolvingProgrammingProblems.Infrastructure.API;
using SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface;
using SandboxForSolvingProgrammingProblems.Models;
using SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.AutoSettingsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu
{
    class AutoSettingsSideViewModel : BaseSideViewModel
    {

        //Copy link to requestEvaluation in Heap (Base)
        public AutoSettingsSideViewModel(RequestEvaluation requestEvaluation) : base(requestEvaluation)
        {
            managerTaskAPI = ManagerTaskAPI.GetInstance();
        }

        public AutoSettingsSideViewModel(RequestEvaluation requestEvaluation, IDictionary<string, string> listTask) : this(requestEvaluation)
        {
            this.ListTask = listTask;
            SelectedSideView = new ListTaskViewModel(ListTask);
        }

        private IManagerTask managerTaskAPI;


        private IDictionary<string, string> listTask;

        public IDictionary<string, string> ListTask
        {
            get
            {
                return listTask;
            }

            set
            {
                listTask = value;
            }
        }

        private BaseAutoViewModel selectedSideView;

        public BaseAutoViewModel SelectedSideView
        {
            get
            {
                return selectedSideView;
            }
            set
            {
                if (value is not BaseAutoViewModel)
                {
                    selectedSideView = new ListTaskViewModel(ListTask);
                }
                selectedSideView = value;
            }
        }
    }
}
