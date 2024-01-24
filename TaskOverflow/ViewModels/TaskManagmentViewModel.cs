using Avalonia;
using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using TaskOverflow.Models.TaskManagement;

//Per evitare conflitti con il tipo Task della libreria System
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow.ViewModels
{
    public class TaskManagmentViewModel : ViewModelBase
    {
        private TasksHandler TH { get; set; }
        public ObservableCollection<Task> TaskList { get; }

        //input binded variables
        public MainTask CreationTask { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public TaskManagmentViewModel(TasksHandler TH)
        {
            this.TH = TH;
            TaskList = this.TH.tasks;
            CreationTask = new();
            Date = DateTimeOffset.Now;
        }

        public void prioritySelector(int priority)
        {
            System.Diagnostics.Debug.WriteLine($"\npriority: {priority}\n");
            CreationTask.priority = priority; 
        }

        public void createTask()
        {
            DateTime newDate = Date.UtcDateTime;
            //Aggiungo un ora poiché per qualche motivo durante la conversione ne sparisce una, non so perché
            Time = Time.Add(new TimeSpan(1, 0, 0)); 
            newDate = newDate.Add(Time);
            
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

            MainTask newTask = new();
            newTask.name = CreationTask.name;
            newTask.description= CreationTask.description;
            newTask.date = newDate;
            newTask.priority = CreationTask.priority;

            TaskList.Add((Task)newTask);
        }

        //DEBUG functions
        private void printTaskList()
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

        private void printTHlist()
        {
            System.Diagnostics.Debug.WriteLine("Model TaskHandler task list");
            foreach (Task Task in TH.tasks)
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

        public void debugFunc()
        {
            System.Diagnostics.Debug.WriteLine("\ndebugFunc stream start: \n");

            System.Diagnostics.Debug.WriteLine("Hello :) \n");

            System.Diagnostics.Debug.WriteLine("\ndebugFunc stream end: \n");
        }

    }
}