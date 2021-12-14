using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class OrderProduct
    {
        public int OrderProductID { get; set; }
        public string Products { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
