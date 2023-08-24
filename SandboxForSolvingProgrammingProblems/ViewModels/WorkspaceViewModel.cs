using SandboxForSolvingProgrammingProblems.Infrastructure.API;
using SandboxForSolvingProgrammingProblems.Infrastructure.Content;
using SandboxForSolvingProgrammingProblems.Models;
using SandboxForSolvingProgrammingProblems.ViewModels.SideMenu;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        private ObservableCollection<Language> languages;

        public ObservableCollection<Language> Languages
        {
            get 
            { 
                return languages; 
            }
            set 
            {
                languages = value;
                SelectedLanguages = languages[0];
                OnPropertyChanged(nameof(Languages));
            }
        }

        private Language selectedLanguages;

        public Language SelectedLanguages
        {
            get
            {
                return selectedLanguages;
            }
            set
            {
                selectedLanguages = value;
                OnPropertyChanged(nameof(selectedLanguages));
            }
        }

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
            Languages = SupportedProgrammingLanguages.SupportedLanguages();
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
