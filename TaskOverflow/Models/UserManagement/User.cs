using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.Models.UserManagement
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }

        public User() { }

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
