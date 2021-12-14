using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models.ViewModels
{
    public class OrderViewModel
    {
        public ICollection<Address> Addresses { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }
        public ICollection<string> Products { get; set; }
        public ICollection<decimal> Prices { get; set; }
        public ICollection<int> Amounts { get; set; }
        public decimal Total { get; set; }
    }
}
