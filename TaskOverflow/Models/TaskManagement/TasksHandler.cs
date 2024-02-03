using Avalonia.Markup.Xaml.Templates;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TaskOverflow.Models.TaskManagement
{
    public enum OrderType
    {
        desc,
        asc
    }
    public class TasksHandler
    {

        public ObservableCollection<Task> tasks { get; set; }

        public TasksHandler()  //constructor
        {
            this.tasks = new ObservableCollection<Task>();
        }

        public bool addTask(Task task) //aggiunge una task alla lista di Task
        {
            if (task == null)
                return false;

            tasks.Add(task);
            return true;
        }

        public bool deleteTask(Task task) //elimina una task dalla lista di Task
        {
            if (task == null)
                return false;

            tasks.Remove(task);
            return true;
        }

        public bool modifyTask(Task oldTask, Task newTask) //modifica una task nella lista di Task
        {
            if (oldTask == null || newTask == null)
                return false;

            if (!tasks.Contains(oldTask))
                return false;

            tasks.Remove(oldTask);
            tasks.Add(newTask);

            return true;
        }

        public bool descSort(Type type) //ordina la lista in modo decrescente.
        {
            if (type == typeof(int))
            {
                sortTasks(new ObservableCollection<Task>(tasks.OrderByDescending(o => o.priority)));
                return true;
            }

            if (type == typeof(DateTime))
            {
                sortTasks(new ObservableCollection<Task>(tasks.OrderByDescending(o => o.date)));
                return true;
            }

            return false;
        }

        public bool ascSort(Type type) //ordina la lista in modo crescente.
        {
            if (type == typeof(int))
            {
                sortTasks(new ObservableCollection<Task>(tasks.OrderBy(o => o.priority)));
                return true;
            }

            if (type == typeof(DateTime))
            {
                sortTasks(new ObservableCollection<Task>(tasks.OrderBy(o => o.date)));
                return true;
            }

            return false;
        }

        public bool orderTasks(Type type, OrderType orderType) //Ordina la lista di task a seconda di quale tipologia di Variabile e in che tipo di ordine vogliamo utilizzare
        {
            if (type == null)
                return false;

            switch (orderType)
            {
                case OrderType.desc:
                    return descSort(type);

                case OrderType.asc:
                    return ascSort(type);

                default:
                    return false;
            }
        }

        private void sortTasks(ObservableCollection<Task> orderedTaks)
        {
            for (int i = 0; i < orderedTaks.Count; i++)
                tasks.Move(tasks.IndexOf(orderedTaks[i]), i);
        }
        
    }
}
