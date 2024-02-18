using ReactiveUI;
using System.Threading.Tasks;
using System;
using TaskOverflow.Models.TaskManagement;
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        //Navigation handling variables
        public ExistingTaskViewModel ExistingTaskVM { get; }
        public AddTaskViewModel AddTaskVM { get; }
        public ModifyTaskViewModel ModifyTaskVM { get; }
        public TasksHandler TH { get; }

        private ViewModelBase _contentViewModel;

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public TaskViewModel(TasksHandler TH)
        {
            this.TH = TH;
            AddTaskVM = new AddTaskViewModel(TH);
            ExistingTaskVM= new ExistingTaskViewModel(TH);
            ModifyTaskVM= new ModifyTaskViewModel(TH);
        }

        //navigation functions
        public void ShowAddTaskView()
        {
            AddTaskVM.ClearInputs();
            ContentViewModel = AddTaskVM;
        }

        public void ShowModifyTaskView()
        {
            ContentViewModel = new ModifyTaskViewModel(TH);
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
    public class AddTaskViewModel : ViewModelBase
    {
        public TasksHandler TH { get; }
        public Task CreationTask { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public AddTaskViewModel(TasksHandler TH) 
        {
            this.TH = TH;
            CreationTask = new();
            CreationTask.name = "";
            CreationTask.description = "";
            Date = DateTimeOffset.Now.Date;
            Date = Date.Date;
            Time = DateTime.Now.TimeOfDay;
            System.Diagnostics.Debug.WriteLine(
                $"Date: {Date} Time {Time}\n"
            );
        }

        public void createTask()
        {
            Task newTask;
            DateTime newDate;

            newDate = Date.Date;
            newDate = newDate.Add(Time);

            if (!string.IsNullOrEmpty(CreationTask.name))
                if (CreationTask.name.Length > 50)
                    return; // Descrizione troppo lunga

            if(!string.IsNullOrEmpty(CreationTask.description))
                if (CreationTask.description.Length > 500)
                    return; // Descrizione troppo lunga

            if(newDate.CompareTo(DateTime.Now) < 0)
                return; // La data di scadenza é prima della data corrente

            newTask = new(
                CreationTask.name,
                CreationTask.description,
                newDate,
                CreationTask.priority
            );

            //Aggiunge il task e pulisce gli input chiudendo la schermata di aggiunta Task
            TH.addTask(newTask);
            CreationTask = new();
        }

        public void PrioritySelector(int priority)
        {
            CreationTask.priority = priority;
        }

        public void ClearInputs()
        {
            CreationTask = new();
            Date = DateTimeOffset.Now;
        }
    }

    public class ModifyTaskViewModel : ViewModelBase 
    {
        public TasksHandler TH { get; }

        private Task toBeModifiedTask { get; set; }
        public Task ModificationTask { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public ModifyTaskViewModel(TasksHandler TH)
        {
            this.TH = TH;
        }

        public void SetModifySelectedTask(Task toBeModifiedTask)
        {
            this.toBeModifiedTask = toBeModifiedTask;
            ModificationTask = toBeModifiedTask;
            Date = ModificationTask.date.Date;
            Time = ModificationTask.date.TimeOfDay;
        }

        public void ModifyTask()
        {
            DateTime newDate;

            newDate = Date.Date;
            newDate = newDate.Add(Time);

            ModificationTask.date = newDate;

            TH.modifyTask(toBeModifiedTask, ModificationTask);
        }

        public void PrioritySelector(int priority)
        {
            ModificationTask.priority = priority;
        }
    }

    public class ExistingTaskViewModel : ViewModelBase
    {
        public TasksHandler TH { get; }

        private Task _selectedTask;
        public Task SelectedTask
        {
            get => _selectedTask;
            set => this.RaiseAndSetIfChanged(ref _selectedTask, value);
        }

        public ExistingTaskViewModel(TasksHandler TH)
        {
            this.TH = TH;
        }

        public void deleteSelectedTask(Task task)
        {
            TH.removeTask(task);
        }
    }
}