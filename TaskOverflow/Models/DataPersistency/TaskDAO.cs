﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Models.UserManagement;
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow.Models.DataPersistency
{
    public class TaskDAO
    {
        private static string connection = @"C:\Temp\database.db";

        public ObservableCollection<Task> getDBTasks(User user) //Recupera tutti i task dal database a seconda dell'activeUser
        {
            if (user == null) return new();

            System.IO.Directory.CreateDirectory(@"C:\Temp\");

            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<Task>("task");
                List<Task> Tasks = new List<Task>();
                Tasks = collection.Query()
                    .Where(task => task.userId.Equals(user.id))
                    .Select(task => task)
                    .ToList();
                return new ObservableCollection<Task>(Tasks);
            }
        }

        public void insertTask(Task task) //Inserisce un task nel database
        {
            if (task == null) return;

            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<Task>("task");
                collection.Insert(task);
            }
        }

        public void deleteTask(Task task) //Cancella un task nel database
        {
            if (task == null) return;

            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<Task>("task");
                collection.Delete(task.id);
            }
        }
    }
}