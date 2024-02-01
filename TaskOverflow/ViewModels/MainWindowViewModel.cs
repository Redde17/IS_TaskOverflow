using ReactiveUI;
using System;
using TaskOverflow.Models.TaskManagement;

namespace TaskOverflow.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private TaskManagementViewModel _taskManagerVM;
        private ViewModelBase _contentViewModel;
        private TasksHandler TH { get; }
         
        public TaskManagementViewModel TaskManagerVM
        {
            get => _taskManagerVM;
            private set => _taskManagerVM = value;
        }
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public MainWindowViewModel()
        {
            //init general data
            TH = new();

            //MainWindow init
            TaskManagerVM = new(TH);
            _contentViewModel = TaskManagerVM;
        }

        public void navigateToUserManager()
        {
            ContentViewModel = new UserManagementViewModel();
        }

        public void navigateToTaskManager()
        {
            ContentViewModel = TaskManagerVM;
        }
    }
}