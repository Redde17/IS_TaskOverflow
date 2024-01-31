using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        //Navigation handling variables
        private ViewModelBase _contentViewModel;

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
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

        public void ShowExistingTaskView()
        {
            ContentViewModel = new ExistingTaskViewModel();
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
        public ExistingTaskViewModel() { }
    }
}
