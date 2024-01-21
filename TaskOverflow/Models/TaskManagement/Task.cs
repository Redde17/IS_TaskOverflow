using Microsoft.VisualBasic;

namespace TaskOverflow.Models.TaskManagement
{
    public class Task
    {
        private int id { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private DateAndTime date {  get; set; }

        public Task(int id, string name, string description, DateAndTime date)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.date = date;
        }
    }
}
