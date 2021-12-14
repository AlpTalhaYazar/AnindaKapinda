using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class CartProduct
    {
        public int CartProductID { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }

        public int CartID { get; set; }
        public Cart Cart { get; set; }
    }
}
