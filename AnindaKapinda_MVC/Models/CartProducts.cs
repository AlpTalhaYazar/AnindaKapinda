using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class CartProducts
    {
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Cart Cart { get; set; }
    }
}
