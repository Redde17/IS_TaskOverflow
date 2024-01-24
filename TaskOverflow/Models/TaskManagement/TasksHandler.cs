using Avalonia.Markup.Xaml.Templates;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TaskOverflow.Models.TaskManagement
{
    public class TasksHandler
    {
        public enum OrderType
        {
            desc,
            asc
        }

        public ObservableCollection<Task> tasks { get; set; }

        public TasksHandler()  //builder
        {
            this.tasks = new ObservableCollection<Task>();
        }

        public bool addTask(Task task) //agguinge una task alla lista di Task
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
            if (oldTask == null && newTask == null)
                return false;

            if (tasks.Contains(oldTask))
                return false;

            tasks.Remove(oldTask);
            tasks.Add(newTask);

            return true;
        }

        public bool descSort(Type type) //ordina la lista in modo decrescente. Trovare un modo piu' ottimizzato per il linguaggio in utilizzo
        {
            int i, j;

            if (tasks == null)
                return false;
            if (type == typeof(DateTime))
            {
                for (i = 0; i < tasks.Count - 1; i++)
                {
                    int max = i;
                    for (j = i + 1; j < tasks.Count; j++)
                    {
                        if (tasks[j].date > tasks[max].date)
                        {
                            max = j;
                            break;
                        }
                    }
                    if (max != i)
                    {
                        Task temp = tasks[max];
                        tasks[i] = tasks[max];
                        tasks[max] = temp;
                    }
                }
                return true;
            }
            return false;

            //else if (type == typeof(int))
            //{
            //    for (i = 0; i < tasks.Count - 1; i++)
            //    {
            //        int max = i;
            //        for (j = i + 1; j < tasks.Count; j++)
            //        {
            //            if (tasks[j].priority > tasks[max].priority) //capire come potrare una lista di MainTasks invece di una lista di Tasks
            //            {
            //                max = j;
            //                break;
            //            }
            //        }
            //        if (max != i)
            //        {
            //            Task temp = tasks[max];
            //            tasks[i] = tasks[max];
            //            tasks[max] = temp;
            //        }
            //    }
            //    return true;
            //}
        }

        public bool ascSort(Type type) //ordina la lista in modo crescente. Trovare un modo piu' ottimizzato per il linguaggio in utilizzo
        {
            int i, j;

            if (tasks == null)
                return false;
            if (type == typeof(DateTime))
            {
                for (i = 0; i < tasks.Count - 1; i++)
                {
                    int min = i;
                    for (j = i + 1; j < tasks.Count; j++)
                    {
                        if (tasks[j].date < tasks[min].date)
                        {
                            min = j;
                            break;
                        }
                    }
                    if (min != i)
                    {
                        Task temp = tasks[min];
                        tasks[i] = tasks[min];
                        tasks[min] = temp;
                    }
                }
                return true;
            }
            return false;

            //else if (type == typeof(int))
            //{
            //    for (i = 0; i < tasks.Count - 1; i++)
            //    {
            //        int min = i;
            //        for (j = i + 1; j < tasks.Count; j++)
            //        {
            //            if (tasks[j].priority < tasks[min].priority) //capire come potrare una lista di MainTasks invece di una lista di Tasks
            //            {
            //                min = j;
            //                break;
            //            }
            //        }
            //        if (min != i)
            //        {
            //            Task temp = tasks[min];
            //            tasks[i] = tasks[min];
            //            tasks[min] = temp;
            //        }
            //    }
            //    return true;
            //}
        }

        public bool orderTasks(Type type, OrderType orderType) //Ordina la lista di task a seconda di quale tipologia di Variabile e in che tipo di ordine vogliamo utilizzare
        {
            if (type == null)
                return false;

            switch (orderType)
            {
                case OrderType.desc:
                    if (descSort(type)) 
                        return true;
                    return false;

                case OrderType.asc:
                    if (ascSort(type))
                        return true;
                    return false;

                default:
                    return false;
            }
        }
    }
}
