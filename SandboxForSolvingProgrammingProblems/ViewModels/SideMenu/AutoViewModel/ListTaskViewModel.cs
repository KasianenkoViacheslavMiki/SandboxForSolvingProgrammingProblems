using SandboxForSolvingProgrammingProblems.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.AutoViewModel
{
    class ListTaskViewModel : BaseAutoViewModel
    {
        public event Action<string> OnSelectedTask;

        public ListTaskViewModel(IDictionary<string, string> listTask)
        {
            ListTask = new ObservableCollection<(string, string)>();
            foreach (var task in listTask)
            {
                ListTask.Add((task.Key, task.Value));
            }
        }

        public ListTaskViewModel()
        {
        }


        private ICommand taskCommand;

        public ICommand TaskCommand
        {
            get
            {
                return taskCommand ?? (taskCommand = new RelayCommand(async obj =>
                {
                    OnSelectedTask((string) obj);
                }));
            }
        }

        private ObservableCollection<(string, string)> listTask;

		public ObservableCollection<(string, string)> ListTask
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

        

        private (string, string) selectedTask;

        public (string, string) SelectedTask
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
