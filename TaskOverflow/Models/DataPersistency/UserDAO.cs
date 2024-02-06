using LiteDB;
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

        public ObservableCollection<User> getDBUsers()
        {
            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<User>("Users");
                List<User> Users = new List<User>();
                Users = collection.Query()
                    .Select(user => user)
                    .ToList();
                return new ObservableCollection<User>(Users);
            }
        }

        public void insertUser(User user)
        {
            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<User>("user");
                collection.Insert(user);
            }
        }

        public void deleteUser(User user)
        {
            using (var db = new LiteDatabase(connection))
            {
                var collection = db.GetCollection<User>("user");
                collection.Delete(user.id);
            }
        }
    }
}
