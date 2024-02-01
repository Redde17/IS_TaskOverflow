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
            
            return userHandler.addUser(user);
        }

        public bool removeUser(User user)
        {
            if (user == null)
                return false;

            return userHandler.removeUser(user);
        }

        public bool modifyUser(User oldUser, User newUser)
        {
            if (oldUser == null || newUser == null)
                return false;

            return userHandler.modifyUser(oldUser, newUser);
        }

        public bool chooseActiveUser(User user)
        {
            if (user == null)
                return false;

            return userHandler.chooseActiveUser(user);
        }
    }
}
