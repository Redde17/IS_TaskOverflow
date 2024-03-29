﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow.Models.DataPersistency
{
    public class UserDAO
    {
        private static string connection = @"C:\Temp\database.db";

        public ObservableCollection<User> getDBUsers() //Recupera tutti gli user all'interno del database
        {
            System.IO.Directory.CreateDirectory(@"C:\Temp\");

            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<User>("user");
                List<User> Users = new List<User>();
                Users = collection.Query()
                    .Select(user => user)
                    .ToList();
                return new ObservableCollection<User>(Users);
            }
        }

        public void insertUser(User user) //Inserisce un utente all'interno del database
        {
            if (user == null) return;

            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<User>("user");
                collection.Insert(user);
            }
        }

        public void deleteUser(User user) //Elimina un utente dal database
        {
            using (var db = new LiteDatabase(connection))
            {
                var userCollection = db.GetCollection<User>("user");
                userCollection.Delete(user.id);

                //delete users tasks
                var tasksCollection = db.GetCollection<Task>("task");
                tasksCollection.DeleteMany(task => task.userId == user.id);
            }
        }

        public void modifyUser(User user)
        {
            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<User>("user");
                collection.Update(user);
            }
        }
    }
}
