using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectKeonWooPark1831319.Models
{
    public class DetailSaleInformation
    {
        public List<Brand> Brands { get; set; }
        public List<CarModel> Models { get; set; }
        public List<Sale> Sales { get; set; }
        public List<User> Users { get; set; }
    }
}