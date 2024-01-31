using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.Models.TaskManagement
{
    public enum OrderType : int
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

            bool check = tasksHandler.addTask(task);
            return check;
        }

        public bool removeTask(Task task)
        {
            if (task == null) 
                return false;

            bool ckeck = tasksHandler.deleteTask(task);
            return ckeck;
        }

        public bool modifyTask(Task oldTask, Task newTask)
        {
            if (oldTask == null || newTask == null)
                return false;

            bool check = tasksHandler.modifyTask(oldTask, newTask);
            return check;
        }

        public bool descSort(Type type)
        {
            if (type  == null) 
                return false;

            bool check = tasksHandler.descSort(type);
            return check;
        }

        public bool ascSort(Type type)
        {
            if (type == null)
                return false;

            bool check = tasksHandler.ascSort(type);
            return check;
        }

        public bool orderTasks(Type type, OrderType orderType)
        {
            if (type == null)
                return false;

            bool check = tasksHandler.orderTasks(type, (int)orderType);
            return check;
        }
    }
}
