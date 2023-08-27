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
        public event Action<string>? SelectedTask;
        public event Action<string>? ReturnToListTask;

        protected void OnSelectedTask(string value)
        {
            SelectedTask?.Invoke(value);
        }
        protected void OnReturnToListTask(string value)
        {
            ReturnToListTask?.Invoke(value);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
