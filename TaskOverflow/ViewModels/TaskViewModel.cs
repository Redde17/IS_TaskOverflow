using ReactiveUI;
using TaskOverflow.Models.TaskManagement;

namespace TaskOverflow.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        //Navigation handling variables
        public ExistingTaskViewModel ExistingTaskVM { get; }
        private ViewModelBase _contentViewModel;

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public TaskViewModel()
        {
            ExistingTaskVM= new ExistingTaskViewModel();
        }

        //navigation functions
        public void ShowAddTaskView()
        {
            ContentViewModel = new AddModifyTaskViewModel();
        }

        public void ShowModifyTaskView()
        {
            ContentViewModel = new AddModifyTaskViewModel();
        }

        public void ShowExistingTaskView(Task selectedTask)
        {
            ExistingTaskVM.SelectedTask = selectedTask;
            ContentViewModel = ExistingTaskVM;
        }

        public void ShowNothing()
        {
            ContentViewModel = null;
        }
    }
    public class AddModifyTaskViewModel : ViewModelBase
    {
        public AddModifyTaskViewModel() { }
    }

    public class ExistingTaskViewModel : ViewModelBase
    {
        private Task _selectedTask;
        public Task SelectedTask 
        { 
            get => _selectedTask;
            set => this.RaiseAndSetIfChanged(ref _selectedTask, value);
        }
    }
}

