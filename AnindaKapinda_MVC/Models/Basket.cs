using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class Basket
    {
        public int BasketID { get; set; }
        public List<string> Products { get; set; }
        public int amount { get; set; }
        public decimal Total { get; set; }
    }
}
