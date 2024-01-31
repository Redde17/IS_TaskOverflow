using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.Models.UserManagement
{
    public class UserHandler
    {
        public ObservableCollection<User> users { get; set; }
        public User activeUser { get; set; }

        public UserHandler(User activeUser)
        {
            this.users = new ObservableCollection<User>();
            this.activeUser = activeUser;
        }

        public bool addUser(User user)
        {
            if (user == null)
                return false;

            users.Add(user);
            return true;
        }

        public bool removeUser(User user) 
        {  
            if (user == null) 
                return false;
            
            users.Remove(user); 
            return true; 
        }

        public bool modifyUser(User oldUser, User newUser)
        {
            if (oldUser == null || newUser == null)
                return false;

            if (users.Contains(oldUser))
                return false;

            users.Remove(oldUser);
            users.Add(newUser); 

            return true;
        }

        public bool chooseActiveUser(User user)
        {
            if (user == null)
                return false;

            activeUser = user;
            return true;
        }

    }
}
