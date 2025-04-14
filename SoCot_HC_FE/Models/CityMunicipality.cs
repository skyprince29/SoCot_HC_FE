using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
      public class CityMunicipality
    {
       
        public int city_municipality_id { get; set; }


        public int province_id { get; set; }
        public Province Province { get; set; }


        public string city_municipality_name { get; set; }

        public int province_code { get; set; }
        public int city_municipality_code { get; set; }
    }
}