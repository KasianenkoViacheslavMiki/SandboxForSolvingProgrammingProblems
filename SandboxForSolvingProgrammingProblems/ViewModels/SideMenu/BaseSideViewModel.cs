using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu
{
    class BaseSideViewModel : INotifyPropertyChanged
    {
        protected RequestEvaluation requestEvaluation;

        public event Action<bool> Load;

        public event Action<object> SelectedTask;

        public event Action<object> RemoveSelectedTask;

        protected void OnRemoveSelectedTask(object value)
        {
            RemoveSelectedTask?.Invoke(value);
        }
        protected void OnSelectedTask(object value)
        {
            SelectedTask?.Invoke(value);
        }
        protected void OnLoad(bool value)
        {
            Load?.Invoke(value);
        }

        //Copy link to requestEvaluation in Heap
        public BaseSideViewModel(RequestEvaluation requestEvaluation)
        {
            this.requestEvaluation = requestEvaluation;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
