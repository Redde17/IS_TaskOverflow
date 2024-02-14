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
        private string _userListTitleText;

        public User CreationUser 
        { 
            get => _creationUser;
            private set => this.RaiseAndSetIfChanged(ref _creationUser, value);
        }

        public string UserListTitleText
        {
            get => _userListTitleText;
            private set => this.RaiseAndSetIfChanged(ref _userListTitleText, value);
        }

        public UserHandler UH { get; }
        public UserManagementViewModel(UserHandler UH) 
        {
            this.UH = UH;
            CreationUser = new User();

            UserListChanged();
        }

        public void StartAddUser()
        {
            CreationUser = new();
        }

        public void AddUser()
        {
            if (CreationUser.name.Length > 30) return;

            printDebug($"Adding user with name: {CreationUser.name}");
            UH.addUser( CreationUser );
            UserListChanged();
        }

        public void UserListChanged()
        {
            if(UH.users.Count > 0)
                UserListTitleText = "Seleziona un profilo";
            else
                UserListTitleText = "Crea un nuovo profilo";
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
