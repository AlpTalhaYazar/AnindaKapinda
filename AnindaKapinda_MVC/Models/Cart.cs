using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Cart
    {
        public int BasketID { get; set; }
        public ICollection<CartProducts> CartProducts { get; set; }
        public decimal Total 
        {
            get 
            {
                return CartProducts.Select(x => x.Price * x.Amount).Sum();
            }
        }
        public Client Client { get; set; }
    }
}
