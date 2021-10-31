using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Products { get; set; }
        public Enumerations.OrderStatus OrderStatus { get; set; }
        public Enumerations.DeliveryStatus DeliveryStatus { get; set; }
        public Employee Employee { get; set; }
    }
}
