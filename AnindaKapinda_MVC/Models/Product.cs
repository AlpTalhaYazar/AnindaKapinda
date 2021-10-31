using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountRate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public decimal DiscountedPrice 
        {
            get 
            {
                return Price * DiscountRate;
            }
        }

        public Category Category { get; set; }
    }
}
