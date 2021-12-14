using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public decimal Total { get; set; }

        public string ClientID { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
