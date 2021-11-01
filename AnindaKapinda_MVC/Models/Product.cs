using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Range(0, 100)]
        public int DiscountRate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }

        public decimal DiscountedPrice
        {
            get
            {
                return Price - (Price * DiscountRate / 100);
            }
        }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
