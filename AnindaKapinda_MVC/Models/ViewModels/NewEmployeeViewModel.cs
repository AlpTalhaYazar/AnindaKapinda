using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models.ViewModels
{
    public class NewEmployeeViewModel
    {
        public Employee Employee { get; set; }
        public string RoleID { get; set; }
    }
}
