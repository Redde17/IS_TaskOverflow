using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.Models.UserManagement
{
    internal class UserFacade
    {
        public UserHandler userHandler {  get; set; }

        public UserFacade(UserHandler userHandler)
        {
            this.userHandler = userHandler;
        }

        public bool addUser(User user) //aggiunge uno user tramite l'interfaccia facade
        {
            if (user == null)
                return false;
            
            bool check = userHandler.addUser(user);
            return check;
        }

        public bool removeUser(User user)
        {
            if (user == null)
                return false;

            bool check = userHandler.removeUser(user);
            return check;
        }

        public bool modifyUser(User oldUser, User newUser)
        {
            if (oldUser == null || newUser == null)
                return false;

            bool check = userHandler.modifyUser(oldUser, newUser);
            return check;
        }

        public bool chooseActiveUser(User user)
        {
            if (user == null)
                return false;

            bool check = userHandler.chooseActiveUser(user);
            return check;
        }
    }
}
