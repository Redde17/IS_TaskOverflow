using Avalonia.Controls.Shapes;
using DynamicData.Kernel;
using Microsoft.VisualBasic;
using System;

namespace TaskOverflow.Models.TaskManagement
{
    public class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date {  get; set; }
        public int priority { get; set; }

        public Task() { }

        public Task(int id, string name, string description, DateTime date, int priority) //constructor
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.date = date;
            this.priority = priority;
        }
    }
}