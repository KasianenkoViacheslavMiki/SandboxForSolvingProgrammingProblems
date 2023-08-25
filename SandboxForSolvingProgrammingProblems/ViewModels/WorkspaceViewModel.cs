using SandboxForSolvingProgrammingProblems.Infrastructure;
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
using System.Threading;
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
                return runCommand ?? (runCommand = new RelayCommand(async obj =>
                {
                    requestEvaluation.Source = CodeText;
                    requestEvaluation.Lang = SelectedLanguages.LangArgument;
                    ResponceEvaluation = await managerSandboxAPI.GetCodeOnEvaluation(requestEvaluation);

                    Thread threadStatus = new Thread(async obj =>
                    {
                        while (ResponceEvaluation.RequestStatus.Code != "REQUEST_FAILED" && ResponceEvaluation.RequestStatus.Code != "REQUEST_COMPLETED")
                        {
                            Thread.Sleep(5000);
                            ResponceEvaluation = await managerSandboxAPI.GetStatus(ResponceEvaluation.StatusUpdateUrl);
                        }
                        OutputString = await managerSandboxAPI.GetOutput(ResponceEvaluation.Result.RunStatus.Output);
                    });

                    threadStatus.IsBackground = true;

                    threadStatus.Start();
                }));
            }
        }

        private RelayCommand statusCommand;
        public ICommand StatusCommand
        {
            get
            {
                return statusCommand ?? (statusCommand = new RelayCommand(async obj =>
                {
                    ResponceEvaluation = await managerSandboxAPI.GetStatus(ResponceEvaluation.StatusUpdateUrl);
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
        private Responce responceEvaluation;

        //Parametrs

        public Responce ResponceEvaluation 
        {
            get 
            { 
                if (responceEvaluation == null)
                {
                    responceEvaluation = new Responce();
                    responceEvaluation.RequestStatus = new RequestStatus();
                }
                return responceEvaluation; 
            }
            set 
            { 
                responceEvaluation = value;
                OnPropertyChanged(nameof(StatusString));
                OnPropertyChanged(nameof(InputString));
                OnPropertyChanged(nameof(ExpectedOutputString));
                OnPropertyChanged(nameof(ResponceEvaluation));
            }
        }

        public string? StatusString
        {
            get 
            { 
                return ResponceEvaluation.RequestStatus.Message; 
            }
        }

        public string? InputString
        {
            get
            {
                return requestEvaluation.Input;
            }
        }

        private string outputString = "";
        public string? OutputString
        {
            get
            {
                return outputString;
            }
            set
            {
                outputString = value;
                OnPropertyChanged(nameof(OutputString));
            }
        }
        public string? ExpectedOutputString
        {
            get
            {
                return "Stub";
            }
        }

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
