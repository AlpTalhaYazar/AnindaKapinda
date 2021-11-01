using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public decimal Total 
        {
            get 
            {
                return CartProducts.Select(x => x.Price * x.Amount).Sum();
            }
        }

        public string ClientID { get; set; }
        public Client Client { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
