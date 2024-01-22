using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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

        public List<Task> tasks { get; private set; }

        public TasksHandler()
        {
            this.tasks = new List<Task>();
        }

        public bool createTask(Task task)
        {
            if (task == null)
                return false;

            tasks.Add(task);
            return true;
        }

        public bool deleteTask(Task task)
        {
            if (task == null)
                return false;

            tasks.Remove(task);
            return true;
        }

        public bool modifyTask(Task oldTask, Task newTask)
        {
            if (oldTask == null && newTask == null)
                return false;

            if (tasks.Contains(oldTask))
                return false;

            tasks.Remove(oldTask);
            tasks.Add(newTask);

            return true;
        }

        //public bool orderTasks(Type type, OrderType orderType)
        //{
        //    if (type == null) 
        //        return false;

        //    switch (orderType)
        //    {
        //        case OrderType.desc:
        //            break;

        //        case OrderType.asc:
                    
        //            break;

        //        default:
        //            return false;
        //            break;
        //    }
        //}

        //public bool orderTasks()
        //{

        //}
    }
}
