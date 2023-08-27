using SandboxForSolvingProgrammingProblems.Infrastructure;
using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.AutoSettingsModel
{
    class ListTaskViewModel : BaseAutoViewModel
    {
        public event Action<string> OnSelectedTask;

        public ListTaskViewModel(IDictionary<string, string> listTask)
        {
            ListTask = new ObservableCollection<TaskItem>();
            foreach (var task in listTask)
            {
                ListTask.Add(new TaskItem(task.Key, task.Value));
            }
        }

        public ListTaskViewModel()
        {
        }

        private ICommand selectedTaskCommand;

        public ICommand SelectedTaskCommand
        {
            get
            {
                return selectedTaskCommand ?? (selectedTaskCommand = new RelayCommand(async obj =>
                {
                    OnSelectedTask((string) obj);
                }));
            }
        }

        private ObservableCollection<TaskItem> listTask;

		public ObservableCollection<TaskItem> ListTask
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

        

        private TaskItem selectedTask;

        public TaskItem SelectedTask
        {
            get 
            { 
                return selectedTask; 
            }
            set 
            { 
                selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

    }
}
