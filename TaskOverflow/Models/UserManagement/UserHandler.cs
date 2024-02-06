using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskOverflow.Models.DataPersistency;

namespace TaskOverflow.Models.UserManagement
{
    public class UserHandler
    {
        public ObservableCollection<User> users { get; set; } 
        private UserDAO userDAO { get; set; }
        public User activeUser { get; private set; }

        /*
        TODO
        Trovare un modo per:
        1) Controllare se l'active user funzioni
        */

        public UserHandler() //constructor
        {
            this.userDAO = new UserDAO();
            this.users = userDAO.getDBUsers();
        }

        public bool addUser(User user) //aggiunge uno user all'interno della lista di Users
        {
            if (user == null)
                return false;

            users.Add(user);
            userDAO.insertUser(user);

            return true;
        }

        public bool removeUser(User user) //rimuove uno user dalla lista di Users
        {  
            if (user == null) 
                return false;
            
            users.Remove(user);
            userDAO.deleteUser(user);

            return true; 
        }

        public bool modifyUser(User oldUser, User newUser) //modifica uno user dalla lista di Users
        {
            if (oldUser == null || newUser == null)
                return false;

            if (users.Contains(oldUser))
                return false;

            users.Remove(oldUser);
            users.Add(newUser);

            userDAO.deleteUser(oldUser);
            userDAO.insertUser(newUser);
            return true;
        }

        public bool chooseActiveUser(User user) //Cambia lo user attivo in quel esatto momento.
        {
            if (user == null)
                return false;

            activeUser = user;
            return true;
        }
    }
}
