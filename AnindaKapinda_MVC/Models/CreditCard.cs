using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CardHolder { get; set; }
        public string SecurityCode { get; set; }

        public Client Client { get; set; }
    }
}
