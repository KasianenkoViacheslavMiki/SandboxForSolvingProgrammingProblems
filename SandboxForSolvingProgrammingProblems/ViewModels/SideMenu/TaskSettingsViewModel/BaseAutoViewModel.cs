using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.TaskSettingsModel
{
    class BaseAutoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action<object>? SelectedTask;
        public event Action<object>? ReturnToListTask;

        protected void OnSelectedTask(object value)
        {
            SelectedTask?.Invoke(value);
        }
        protected void OnReturnToListTask(object value)
        {
            ReturnToListTask?.Invoke(value);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
