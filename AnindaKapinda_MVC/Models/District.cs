using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class District
    {
        public int DistrictID { get; set; }
        public string Name { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }
    }
}
