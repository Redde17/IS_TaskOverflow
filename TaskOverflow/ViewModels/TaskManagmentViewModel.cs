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
        public Task CreationTask { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public TaskManagmentViewModel(TasksHandler TH)
        {
            this.TH = TH;
            //Task per testare 
            this.TH.createTask(new Task(1, "test1", "descrizione 1", DateTime.Now));
            this.TH.createTask(new Task(1, "test2", "descrizione 2", DateTime.Now));

            TaskList = new ObservableCollection<Task>(this.TH.tasks);
            CreationTask = new();
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
                $"Binded Time: {Time}\n"
                );

            Task newTask = new();
            newTask.name = CreationTask.name;
            newTask.description= CreationTask.description;
            newTask.date = newDate; 

            TaskList.Add(newTask);
        }

        public void addTask(string name, string description, string date, string time, int id = 0)
        {
            //TODO: Parse date from string date and time to DateTime format
            //for now i'm using DateTime.Now as debug
            //TaskList.Add(new Task(id, name, description, DateTime.Now));

            System.Diagnostics.Debug.WriteLine(
            string.Format(
                $"id = {id}\n" +
                $"nome = {name}\n" +
                $"descrizione = {description}\n" +
                $"Data = {date} + {time}\n"
                )
            );
        }

        //public void addTask(string name, string description, DateTime date, int id = 0)
        //{
        //    TaskList.Add(new Task(id, name, description, date));
        //}

        ////DEBUG functions
        //public void addTaskDEBUG()
        //{
        //    addTask("ButtonAddTest", "Descrizione 1", DateTime.Now, 1);

        //    System.Diagnostics.Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        //    printTaskList();
        //    printTHlist();
        //    System.Diagnostics.Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        //}

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
    }
}