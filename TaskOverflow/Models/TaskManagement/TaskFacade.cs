using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.Models.TaskManagement
{
    public enum OrderType
    {
        desc,
        asc
    }

    public class TaskFacade 
    {
        private TasksHandler tasksHandler {  get; set; }

        public TaskFacade(TasksHandler tasksHandler)
        {
            this.tasksHandler = tasksHandler;
        }

        public bool addTask(Task task)
        {
            if (task == null)
                return false;

            return tasksHandler.addTask(task);
        }

        public bool removeTask(Task task)
        {
            if (task == null) 
                return false;

            return tasksHandler.deleteTask(task);
        }

        public bool modifyTask(Task oldTask, Task newTask)
        {
            if (oldTask == null || newTask == null)
                return false;

            return tasksHandler.modifyTask(oldTask, newTask);
        }

        public bool descSort(Type type)
        {
            if (type  == null) 
                return false;

            return tasksHandler.descSort(type);
        }

        public bool ascSort(Type type)
        {
            if (type == null)
                return false;

            return tasksHandler.ascSort(type);
        }

        public bool orderTasks(Type type, OrderType orderType)
        {
            if (type == null)
                return false;

            return tasksHandler.orderTasks(type, orderType);
        }
    }
}
