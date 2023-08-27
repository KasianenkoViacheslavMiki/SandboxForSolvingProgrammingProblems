using SandboxForSolvingProgrammingProblems.Infrastructure;
using SandboxForSolvingProgrammingProblems.Infrastructure.API;
using SandboxForSolvingProgrammingProblems.Infrastructure.API.Interface;
using SandboxForSolvingProgrammingProblems.Models;
using SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.TaskSettingsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu
{
    class TaskSettingsSideViewModel : BaseSideViewModel
    {

        //Copy link to requestEvaluation in Heap (Base)
        public TaskSettingsSideViewModel(RequestEvaluation requestEvaluation) : base(requestEvaluation)
        {
            managerTaskAPI = ManagerTaskAPI.GetInstance();
        }

        public TaskSettingsSideViewModel(RequestEvaluation requestEvaluation, IDictionary<string, string> listTask, string? selectedTask = null) : this(requestEvaluation)
        {
            this.ListTask = listTask;
            if (selectedTask == null)
            {
                SelectedSideView = new ListTaskViewModel(ListTask);
            }
            else
            {
                OpenSelectedTaskViewModel((string)selectedTask);
            }
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
                OnPropertyChanged(nameof(ListTask));
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
                    selectedSideView.SelectedTask += OpenSelectedTaskViewModel;
                    selectedSideView.ReturnToListTask += ReturnToListTask;
                }
                else
                {
                    selectedSideView = value;
                    selectedSideView.SelectedTask += OpenSelectedTaskViewModel;
                    selectedSideView.ReturnToListTask += ReturnToListTask;
                }
                OnPropertyChanged(nameof(SelectedSideView));
            }
        }

        private void ReturnToListTask(object obj)
        {
            SelectedSideView = new ListTaskViewModel(ListTask);
            OnRemoveSelectedTask(obj);
        }

        private async void OpenSelectedTaskViewModel(object obj)
        {
            OnLoad(true);
            try
            {
                ResponceTask question = await managerTaskAPI.GetTask((string) obj);
                SelectedSideView = new SelectedTaskViewModel(requestEvaluation, question.Question);
                OnSelectedTask(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error settings", MessageBoxButton.OK, MessageBoxImage.Error);
                OnLoad(false);
                return;
            }
            OnLoad(false);
        }
    }
}
