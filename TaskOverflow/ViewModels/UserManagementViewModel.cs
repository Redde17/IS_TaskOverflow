using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private User _creationUser;
        public User CreationUser 
        { 
            get => _creationUser;
            private set => this.RaiseAndSetIfChanged(ref _creationUser, value);
        }

        public UserHandler UH { get; }
        public UserManagementViewModel(UserHandler UH) 
        {
            this.UH = UH;
            CreationUser = new User();

            //UH.addUser(new User(1, "Name1"));
            //UH.addUser(new User(2, "Name2"));
            //UH.addUser(new User(3, "Name3"));
            //UH.addUser(new User(4, "Name4"));

            if (UH.users.Count == 0)
                System.Diagnostics.Debug.WriteLine($"User list empty\n");
            foreach (User user in UH.users) 
            {
                System.Diagnostics.Debug.WriteLine(
                    $"\nID: {user.id} NAME: {user.name}\n"
                );
            }
        }

        public void StartAddUser()
        {
            CreationUser = new();
        }

        public void AddUser()
        {
            printDebug($"Adding user with name: {CreationUser.name}");
            UH.addUser( CreationUser );
        }

        //Debug functions
        public void printDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(
                $"\nDEBUG message:\n{message}\n"
            );
        }
    }
}
