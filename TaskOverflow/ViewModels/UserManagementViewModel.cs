using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        public UserHandler UH { get; }
        public UserManagementViewModel() 
        {
            User tempUser = new User();
            UH = new(tempUser);
        }
    }
}
