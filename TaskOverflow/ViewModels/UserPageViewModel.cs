using ReactiveUI;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow.ViewModels
{
    public class UserPageViewModel : ViewModelBase
    {
        private UserHandler UH { get; }
        private User _modifiedActiveUser;
        private string _userName;
        public string UserName { 
            get => UH.activeUser.name; 
            private set => this.RaiseAndSetIfChanged(ref _userName, value); 
        }
        public User ModifiedActiveUser
        {
            get => _modifiedActiveUser;
            private set => this.RaiseAndSetIfChanged(ref _modifiedActiveUser, value);
        }

        public UserPageViewModel(UserHandler UH) 
        {
            this.UH = UH;

            _modifiedActiveUser = new();
        }

        public void StartModifyUser()
        {
            System.Diagnostics.Debug.WriteLine(
                "User modification button pressed, process started\n"
            );
            ModifiedActiveUser = UH.activeUser;
        }

        public void EndModifyUser()
        {
            //ModifiedActiveUser = NewCurrentActiveUser;
            System.Diagnostics.Debug.WriteLine(
                "User modification button pressed process finalizing\n"
            );
            UH.modifyUser(UH.activeUser, ModifiedActiveUser);

            //notify change
            //change is only to trigger the change to the ui, the actual value of the variable is not really used
            //as the information used is from the UserHandler directly 
            UserName = ModifiedActiveUser.name;
        }
    }
}
