﻿using SandboxForSolvingProgrammingProblems.Infrastructure;
using SandboxForSolvingProgrammingProblems.Infrastructure.API;
using SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface;
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
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels
{
    class WorkspaceViewModel : BaseViewModel
    {
        //Command
        private RelayCommand runCommand;
        public ICommand RunCommand 
        {
            get
            {
                return runCommand ?? (runCommand = new RelayCommand(obj =>
                {
                    requestEvaluation.Source = CodeText;
                    requestEvaluation.Lang = SelectedLanguages.LangArgument;
                    _ = managerSandboxAPI.GetCodeOnEvaluation(requestEvaluation);
                }));
            }
        }

        //Navigation
        private BaseSideViewModel selectedSideView;
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
                    selectedSideView = new ManualSettingsSideViewModel(this.requestEvaluation);
                }
                selectedSideView = value;
            }
        }
        //Manager
        private ISandbox managerSandboxAPI;

        //Content
        private RequestEvaluation requestEvaluation = new RequestEvaluation();

        //Parametrs
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

        private string codeText;

        public string CodeText
        {
            get
            {
                return codeText;
            }
            set
            {
                codeText = value;
                OnPropertyChanged(nameof(CodeText));
            }
        }

        //Construtor
        public WorkspaceViewModel()
        {
            this.selectedSideView = new ManualSettingsSideViewModel(this.requestEvaluation);
            managerSandboxAPI = ManagerSandboxAPI.GetInstance();
            Languages = SupportedProgrammingLanguages.SupportedLanguages();
        }

        
    }
}
