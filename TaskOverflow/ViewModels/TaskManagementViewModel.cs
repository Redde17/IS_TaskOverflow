﻿using Avalonia;
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
        public TasksHandler TH { get; }

        private int _taskListComboBoxSelectedIndex;
        private int _comboBoxSelectedIndex;
        private TaskViewModel _taskVM;

        public int TaskListComboBoxSelectedIndex
        {
            get => _taskListComboBoxSelectedIndex;
            set
            {
                if (value >= 0)
                    TaskVM.ShowExistingTaskView(TH.tasks[value]);
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
            this.TH = TH;     
            ComboBoxSelectedIndex = 0; // application start with task list sorted by priority up
            _taskListComboBoxSelectedIndex = -1;
            TaskVM = new(this.TH);
        }


        //functional functions
        public void CreateTask()
        {
            TaskVM.AddTaskVM.createTask();
            SortingSelector(ComboBoxSelectedIndex); //Reorder the task list with the new task
            TaskVM.ShowNothing();
        }

        public void DeleteSelectedTask()
        {
            TaskVM.ExistingTaskVM.deleteSelectedTask(TH.tasks[TaskListComboBoxSelectedIndex]);
        }

        public void StartModificationOfSelectedTask()
        {
            TaskVM.ModifyTaskVM.SetModifySelectedTask(TH.tasks[TaskListComboBoxSelectedIndex]);
            TaskVM.ShowModifyTaskView();
        }

        public void StopModificationOfSelectedTask()
        {
            TaskVM.ShowExistingTaskView(TH.tasks[TaskListComboBoxSelectedIndex]);
        }

        public void ModifySelectedTask()
        {
            TaskVM.ModifyTaskVM.ModifyTask();
            SortingSelector(ComboBoxSelectedIndex);
            TaskVM.ShowNothing();
        }

        public void SortingSelector(int selectedIndex)
        {
            //System.Diagnostics.Debug.WriteLine(
            //    "DEBUG\n" +
            //    $"Selected index: {selectedIndex}\n"
            //);

            //Index mapping
            //By prioriy up:    0
            //By prioriy down:  1
            //By date due up:   2
            //By date due down: 3
            //Invalid:          0 > selectedIndex > 3

            Task refTask = new Task();
            switch (selectedIndex)
            {
                case 0:
                    //By prioriy up
                    TH.orderTasks(refTask.priority.GetType(), OrderType.desc);
                    break;
                case 1:
                    //By prioriy down
                    TH.orderTasks(refTask.priority.GetType(), OrderType.asc);
                    break;
                case 2:
                    //By date due up
                    TH.orderTasks(refTask.date.GetType(), OrderType.desc);
                    break;
                case 3:
                    //By date due down
                    TH.orderTasks(refTask.date.GetType(), OrderType.asc);
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


        #region debug functions
        //DEBUG functions
        private void PrintTaskList()
        {
            System.Diagnostics.Debug.WriteLine("ViewModel TaskManagerVM task list");
            foreach (Task Task in TH.tasks)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"id = {Task.id}\n" +
                    $"nome = {Task.name}\n" +
                    $"descrizione = {Task.description}\n" +
                    $"prioritá = {Task.priority}\n" +
                    $"Data = {Task.date}\n"
                );
            }
        }

        public void DebugFunc()
        {
           //Console.WriteLine("\nTest del NotificationHandler\n");
           
           //NotificationHandler notificationHandler = new NotificationHandler();

           //notificationHandler.showableNotifications.CollectionChanged += (sender, e) =>
           //{
           //     Console.WriteLine($"{e.Action}");
           //};
           
           //notificationHandler.pushNotification(new SystemNotification(notificationHandler.generateID(), "Test", "Prova", SystemNotification.NotificationType.Alert));
           //notificationHandler.pushNotification(new TaskNotification(notificationHandler.generateID(), "Test2", "Task di test", new Task(0, "Task", "Task di test", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute+1, 0))));

        }
        #endregion
    }
}