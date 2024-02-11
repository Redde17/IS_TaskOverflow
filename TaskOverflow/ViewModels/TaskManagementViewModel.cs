using Avalonia;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Avalonia.Controls.Notifications;
using TaskOverflow.Models.Notification;
using TaskOverflow.Models.SystemAlert;
using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Views.TaskManagementElems;
using Notification = Avalonia.Controls.Notifications.Notification;

//Per evitare conflitti con il tipo Task della libreria System
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow.ViewModels
{
    public class TaskManagementViewModel : ViewModelBase
    {
        public ObservableCollection<Task> TaskList { get; }
        public MainTask CreationTask { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        private int _taskListComboBoxSelectedIndex;
        private int _comboBoxSelectedIndex;
        private TaskViewModel _taskVM;

        public int TaskListComboBoxSelectedIndex
        {
            get => _taskListComboBoxSelectedIndex;
            set
            {
                if (value >= 0)
                    TaskVM.ShowExistingTaskView(TaskList[value]);
                else
                    TaskVM.ShowNothing();

                _taskListComboBoxSelectedIndex = value;
            }
        }
        public int ComboBoxSelectedIndex
        {
            get => _comboBoxSelectedIndex;
            set
            {
                SortingSelector(value);
                _comboBoxSelectedIndex = value;
            }
        }
        public TaskViewModel TaskVM
        {
            get => _taskVM;
            private set => _taskVM = value;
        }

        public TaskManagementViewModel(TasksHandler TH)
        {
            TaskList = TH.tasks;
            CreationTask = new();
            Date = DateTimeOffset.Now;
            ComboBoxSelectedIndex = 0; // application start with task list sorted by priority up

            TaskVM = new();
        }


        //functional functions
        public void CreateTask()
        {
            MainTask newTask;
            DateTime newDate;

            newDate = Date.UtcDateTime;
            //Aggiungo un ora poiché per qualche motivo durante la conversione ne sparisce una, non so perché
            newDate = newDate.Add(Time.Add(new TimeSpan(1, 0, 0)));

            //DEBUG
            System.Diagnostics.Debug.WriteLine(
                "DEBUG\n" +
                $"CreationTask name: {CreationTask.name}\n" +
                $"CreationTask description: {CreationTask.description}\n" +
                $"generated date: {newDate}\n" +
                $"Binded Date: {Date}\n" +
                $"Binded Time: {Time}\n" +
                $"Priority: {CreationTask.priority}\n"
            );

            newTask = new(
                0, 
                CreationTask.name, 
                CreationTask.description, 
                newDate, 
                CreationTask.priority
            );

            TaskList.Add((Task)newTask);
        }

        public void PrioritySelector(int priority)
        {
            System.Diagnostics.Debug.WriteLine($"\npriority: {priority}\n");
            CreationTask.priority = priority;
        }

        public void SortingSelector(int selectedIndex)
        {
            System.Diagnostics.Debug.WriteLine(
                "DEBUG\n" +
                $"Selected index: {selectedIndex}\n"
            );

            //Index mapping
            //By prioriy up:    0
            //By prioriy down:  1
            //By date due up:   2
            //By date due down: 3
            //Invalid:          0 > selectedIndex > 3

            switch (selectedIndex)
            {
                case 0:
                    //By prioriy up
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by prioriy up\n"
                    );
                    //do the sorting 
                    break;
                case 1:
                    //By prioriy down
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by prioriy down\n"
                    );
                    //do the sorting 
                    break;
                case 2:
                    //By date due up
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by date due up\n"
                    );
                    //do the sorting 
                    break;
                case 3:
                    //By date due down
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by date due down\n"
                    );
                    //do the sorting 
                    break;
                default:
                    //invalid index
                    System.Diagnostics.Debug.WriteLine(
                        "Error in index action parsing\n"
                    );
                    //send error
                    break;
            }

        }

        //DEBUG functions
        private void PrintTaskList()
        {
            System.Diagnostics.Debug.WriteLine("ViewModel TaskManagerVM task list");
            foreach (Task Task in TaskList)
            {
                System.Diagnostics.Debug.WriteLine(
                string.Format(
                    $"id = {Task.id}\n" +
                    $"nome = {Task.name}\n" +
                    $"descrizione = {Task.description}\n" +
                    $"Data = {Task.date}\n"
                    )
                );
            }
        }

        public void DebugFunc()
        {
           Console.WriteLine("\nTest del NotificationHandler\n");
           
           AlertHandler alertHandler = new AlertHandler();
           alertHandler.initHandler();
           
           NotificationHandler notificationHandler = new NotificationHandler(alertHandler);
           
           notificationHandler.pushNotification(new SystemNotification(notificationHandler.generateID(), "Test", "Prova", SystemNotification.NotificationType.Alert));
           notificationHandler.pushNotification(new TaskNotification(notificationHandler.generateID(), "Test2", "Task di test", new Task(0, "Task", "Task di test", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute+1, 0))));

        }
    }
}