using ReactiveUI;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow.ViewModels
{
    public class UserPageViewModel : ViewModelBase
    {
        private User _modifiedActiveUser;
        public User ModifiedActiveUser
        {
            get => _modifiedActiveUser;
            private set => this.RaiseAndSetIfChanged(ref _modifiedActiveUser, value);
        }

        public UserHandler UH { get; }

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
        }
    }
}
