using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public User NewCurrentActiveUser { get; set; }

        public UserPageViewModel(UserHandler UH) 
        {
            this.UH = UH;

            _modifiedActiveUser = new();
        }

        public void modifyUser()
        {
            //ModifiedActiveUser = NewCurrentActiveUser;
                        
        }
    }
}
