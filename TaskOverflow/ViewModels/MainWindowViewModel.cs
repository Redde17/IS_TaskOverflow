using System.Collections.ObjectModel;
using System.Reactive.Linq;
using TaskOverflow.Models.TaskManagement;

namespace TaskOverflow.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TaskManagmentViewModel TaskManagerVM { get; }
        public TasksHandler TH { get; }

        public MainWindowViewModel()
        {
            //init general data
            TH = new();

            //Secondary view models
            TaskManagerVM = new(TH);
        }
    }
}