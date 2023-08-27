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
using System.Windows;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels
{
    class WorkspaceViewModel : BaseViewModel
    {
        //Construtor
        public WorkspaceViewModel()
        {
            this.selectedSideView = new ManualSettingsSideViewModel(this.requestEvaluation);
            managerSandboxAPI = ManagerSandboxAPI.GetInstance();
            managerTaskAPI = ManagerTaskAPI.GetInstance();
            Languages = SupportedProgrammingLanguages.SupportedLanguages();
        }

        #region Command
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
                    IsRunning = true;
                    try
                    {
                        ResponceEvaluation = await managerSandboxAPI.GetCodeOnEvaluation(requestEvaluation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error run", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    Thread threadStatus = new Thread(async obj =>
                    {
                        while (ResponceEvaluation.RequestStatus.Code != "REQUEST_FAILED" && ResponceEvaluation.RequestStatus.Code != "REQUEST_COMPLETED")
                        {
                            Thread.Sleep(5000);
                            try
                            {
                                ResponceEvaluation = await managerSandboxAPI.GetStatus(ResponceEvaluation.StatusUpdateUrl);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error status", MessageBoxButton.OK, MessageBoxImage.Error);
                                IsRunning = false;
                                return;
                            }
                        }
                        OutputString = await managerSandboxAPI.GetOutput(ResponceEvaluation.Result.RunStatus.Output);
                        IsRunning = false;
                    });

                    threadStatus.IsBackground = true;

                    threadStatus.Start();
                }));
            }
        }

        private RelayCommand manualCommand;
        public ICommand ManualCommand
        {
            get
            {
                return manualCommand ?? (manualCommand = new RelayCommand(async obj =>
                {
                    if (SelectedSideView is not ManualSettingsSideViewModel)
                    {
                        SelectedSideView = new ManualSettingsSideViewModel(this.requestEvaluation);
                    }
                }));
            }
        }

        private RelayCommand autoCommand;
        public ICommand AutoCommand
        {
            get
            {
                return autoCommand ?? (autoCommand = new RelayCommand(async obj =>
                {
                    if (SelectedSideView is not AutoSettingsSideViewModel)
                    {
                        if (ListTask.Count == 0)
                        {
                            IsRunningSide = true;
                            try
                            {
                                ListTask = await managerTaskAPI.GetTasksList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error side", MessageBoxButton.OK, MessageBoxImage.Error);
                                IsRunningSide = false;
                                return;
                            }
                            IsRunningSide = false;
                        }

                        SelectedSideView = new AutoSettingsSideViewModel(this.requestEvaluation, ListTask);
                        SelectedSideView.Load += OnOffLoad;
                    }
                }));
            }
        }
        #endregion

        #region Navigation
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
                else
                {
                    selectedSideView = value;
                }
                OnPropertyChanged(nameof(SelectedSideView));
            }
        }
        #endregion

        #region Manager`s instance
        //Manager
        private ISandbox managerSandboxAPI;
        private IManagerTask managerTaskAPI;
        #endregion

        #region Storage content
        //Content
        //Request to API
        private RequestEvaluation requestEvaluation = new RequestEvaluation();

        //Path to Theme
        private Dictionary<bool, string> themeURI = new Dictionary<bool, string>()
        {
            {true,"\\Resources\\Theme\\Dark.xaml" },
            {false,"\\Resources\\Theme\\Default.xaml" }
        };


        //Parametrs

        IDictionary<string, string> listTask = new Dictionary<string, string>();
        public IDictionary<string, string> ListTask 
        {
            get 
            { 
                return listTask; 
            }
            set 
            { 
                listTask = value;
                OnPropertyChanged(nameof(ListTask));
            }
        }
        //Responce from API
        private ResponceEvaluation responceEvaluation;
        public ResponceEvaluation ResponceEvaluation 
        {
            get 
            { 
                if (responceEvaluation == null)
                {
                    responceEvaluation = new ResponceEvaluation();
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
        #endregion

        #region Parameters for show content
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
        #endregion

        #region Change Theme
        private bool toggleTheme = false;
        public bool ToggleTheme
        {
            get
            {
                return toggleTheme;
            }
            set
            {
                var app = (App)Application.Current;
                app.ChangeTheme(new Uri(themeURI[value], UriKind.Relative));
                toggleTheme = value;
                OnPropertyChanged(nameof(ToggleTheme));
            }
        }
        #endregion

        #region Content for Load`s binding 
        private bool isRunningSide = false;
        public bool IsRunningSide
        {
            get
            {
                return !isRunningSide;
            }
            set
            {
                isRunningSide = value;
                OnPropertyChanged(nameof(IsRunningSide));
                OnPropertyChanged(nameof(IsLoadSide));
            }
        }
        public Visibility IsLoadSide
        {
            get
            {
                return isRunningSide ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private bool isRunning = false;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
                OnPropertyChanged(nameof(IsLoad));
            }
        }
        public Visibility IsLoad
        {
            get
            {
                return isRunning ? Visibility.Visible : Visibility.Hidden;
            }
        }
        #endregion

        #region Content for ComboBox`s choosing language binding 
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
        #endregion

        #region Content for TextBox`s input code binding 

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

        #endregion

        #region Method for event
        private void OnOffLoad(bool obj)
        {
            isRunningSide = obj;
        }
        #endregion
    }
}
