using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOverflow.Models.DataPersistency;

namespace TaskOverflow.Models.TaskManagement
{
    public class MainTask : Task
    {
        public int priority { get; set; }

        public MainTask() { }

        public MainTask(int id, string name, string description, DateTime date, int priority) : base(id, name, description, date)
        {
            this.priority = priority;
        }
    }
}
