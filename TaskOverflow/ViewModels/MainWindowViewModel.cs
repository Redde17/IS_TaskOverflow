using ReactiveUI;
using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private TaskManagementViewModel _taskManagerVM;
        private UserManagementViewModel _userManagementVM;
        private UserPageViewModel _userPageVM;
        private ViewModelBase _contentViewModel;
        private int _userListSelectedIndex;

        private UserHandler UH { get; }
        private TasksHandler TH { get; }

        public TaskManagementViewModel TaskManagerVM
        {
            get => _taskManagerVM;
            private set => _taskManagerVM = value;
        }
        public UserManagementViewModel UserManagerVM
        {
            get => _userManagementVM;
            private set => _userManagementVM = value;
        }
        public UserPageViewModel UserPageVM
        {
            get => _userPageVM;
            private set => _userPageVM = value;
        }
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }
        public int UserListSelectedIndex
        {
            get => _userListSelectedIndex;
            set
            {
                if (value >= 0) //change selected user
                    ChangeSelectedUser(value);
                
                //set selected user to none, as the information is not needed anymore
                //keeping it will cause a selected list item to appear on the list during user selection
                //that blocks the selected item from beign selected again.
                _userListSelectedIndex = -1;
            }
        }

        public MainWindowViewModel()
        {
            UH = new UserHandler();
            TH = new TasksHandler(UH);

            //MainWindow init
            TaskManagerVM = new TaskManagementViewModel(TH);
            UserManagerVM = new UserManagementViewModel(UH);
            UserPageVM = new UserPageViewModel(UH);

            _userListSelectedIndex= -1;

            //ContentViewModel = TaskManagerVM;
            ContentViewModel = UserManagerVM;
        }

        public void ChangeSelectedUser(int choosenUserIndex)
        {
            UH.chooseActiveUser(UH.users[choosenUserIndex], TH);
            navigateToTaskManager();
        }

        public void DeleteActiveUser()
        {
            //delete the user
            UH.removeUser(UH.activeUser);

            //navigate to user selection page
            navigateToUserManager();
        }

        //navigation functions
        public void navigateToUserManager()
        {
            ContentViewModel = UserManagerVM;

            //checks for how many users are in the user list to change some gui.
            UserManagerVM.UserListChanged(); 
        }

        public void navigateToTaskManager()
        {
            ContentViewModel = TaskManagerVM;
        }

        public void navigateToUserPage()
        {
            //UserPageVM.changeUser(UH.activeUser);
            ContentViewModel = UserPageVM;
        }
    }
}