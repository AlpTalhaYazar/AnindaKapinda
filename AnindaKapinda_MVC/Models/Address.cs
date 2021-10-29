using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }

        public Client Client { get; set; }
    }
}
