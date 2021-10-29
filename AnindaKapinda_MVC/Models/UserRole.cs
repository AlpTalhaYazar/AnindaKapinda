using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class UserRole
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
