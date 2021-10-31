using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<string> Products { get; set; }
        public bool isPrepared { get; set; }
        public Employee Employee { get; set; }
    }
}
